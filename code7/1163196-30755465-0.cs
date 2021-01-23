    const int BUFFER_SIZE = 3; // no concurrent items to process
    const string XML_FOLDER_PATH = "<whatever>";
     
    public static void Pipeline()
    {
      var bufferXmlFileNames = new BlockingCollection<string>(BUFFER_SIZE);
      var bufferInputXmlDocuments = new BlockingCollection<XmlDocument>(BUFFER_SIZE);
      var bufferWebRequests = new BlockingCollection<HttpWebRequest>(BUFFER_SIZE);
      var bufferSoapResults = new BlockingCollection<string>(BUFFER_SIZE);
      var f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
      // Stage 1: get xml file paths
      var stage1 = f.StartNew(() => {
      try
      {
        foreach (var phrase in Directory.GetFiles(XML_FOLDER_PATH, "*.xml", SearchOption.TopDirectoryOnly))
        { // build concurrent collection
          bufferXmlFileNames.Add(phrase);
        }
      }
      finally
      { // no more additions acceptedin
        bufferXmlFileNames.CompleteAdding();
      }
    });
      // Stage 2: ProduceInputXmlDocuments(bufferXmlFileNames, bufferInputXmlDocuments)
      var stage2 = f.StartNew(() =>  {
      try
      {
        foreach (var xmlFileName in bufferXmlFileNames.GetConsumingEnumerable())
        {
          XmlDocument doc = new XmlDocument();
          doc.Load(xmlFileName);
          bufferInputXmlDocuments.Add(doc);          
        }
      }
      finally
      {
        bufferInputXmlDocuments.CompleteAdding();
      }
    });
      // Stage 3:  PostRequests(BlockingCollection<XmlDocument> xmlDocs, BlockingCollection<HttpWebRequest> posts)
      var stage3 = f.StartNew(() =>  {
      try
      {
        foreach (var xmlDoc in bufferInputXmlDocuments.GetConsumingEnumerable())
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.76.22.135/wpaADws/ADService.asmx");
          request.ContentType = "text/xml;charset=\"utf-8\"";
          request.Accept = "text/xml";
          request.Method = "POST";
          //
          Stream stream = request.GetRequestStream();
          xmlDoc.Save(stream);
          stream.Close();
          //
          bufferWebRequests.Add(request);
        }
      }
      finally
      {
        bufferWebRequests.CompleteAdding();
      }
    });
      // Stage 4: ProcessResponses(bufferWebRequests, bufferSoapResults)
      var stage4 = f.StartNew(() =>
      {
        try
        {
          foreach (var postRequest in bufferWebRequests.GetConsumingEnumerable())
          {
            HttpWebResponse response = (HttpWebResponse)postRequest.GetResponse();
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
              string soapResult = rd.ReadToEnd();
              bufferSoapResults.Add(soapResult);
            }
          }
        }
        finally
        {
          bufferSoapResults.CompleteAdding();
        }
      });
      // stage 5: update UI
      var stage5 = f.StartNew(() =>
      {
        foreach (var soapResult in bufferSoapResults.GetConsumingEnumerable())
        {
          Console.WriteLine(soapResult);
        }
      });
      // display blocking collection load state
      var stageDisplay = f.StartNew(
        () =>
        {
          while (true)
          {
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10}", bufferXmlFileNames.Count, bufferInputXmlDocuments.Count, bufferWebRequests.Count, bufferSoapResults.Count);
            //check last stage completion
            if (stage5.IsCompleted)
              return;
          }
        }
          );
      Task.WaitAll(stage1, stage2, stage3, stage4, stage5, stageDisplay);
    }
