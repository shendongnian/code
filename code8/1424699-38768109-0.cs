    using (Stream objStream = response.GetResponseStream())
    {
      StreamReader sr = new StreamReader(objStream);
                    
      string response = sr.ReadToEnd();
      objStream.Seek(0,SeekOrigin.Begin); // Get the pointer back to the begining.                
    
        query result = (query)serializer.Deserialize(objStream);
        Console.WriteLine(result.results.quote.Name + " " + result.results.quote.Ask);
        objStream.Flush(); // remove
        objStream.Close();//remove
    }
