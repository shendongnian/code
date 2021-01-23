     //HTMLString = Pass your Html , fileLocation = File Store Location
            public void converttopdf(string HTMLString, string fileLocation)
            {
                Document document = new Document();
        
                PdfWriter.GetInstance(document, new FileStream(fileLocation, FileMode.Create));
                document.Open();
        
                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(HTMLString), null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    document.Add((IElement)htmlarraylist[k]);
                }
        
                document.Close();
            }
