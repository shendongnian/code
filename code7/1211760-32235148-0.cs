        private static async Task UseStreams(string colSelfLink)
        {
            var dir = new DirectoryInfo(@".\Data");
            var files = dir.EnumerateFiles("*.json");
            foreach (var file in files)
            {
                using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    Document doc = await client.CreateDocumentAsync(colSelfLink, Resource.LoadFrom<Document>(fileStream));
                    Console.WriteLine("Created Document: ", doc);
                }
            }
            //Read one the documents created above directly in to a Json string
            Document readDoc = client.CreateDocumentQuery(colSelfLink).Where(d => d.Id == "JSON1").AsEnumerable().First();
            string content = JsonConvert.SerializeObject(readDoc);
            //Update a document with some Json text, 
            //Here we're replacing a previously created document with some new text and even introudcing a new Property, Status=Cancelled
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"id\": \"JSON1\",\"PurchaseOrderNumber\": \"PO18009186470\",\"Status\": \"Cancelled\"}")))
            {
                await client.ReplaceDocumentAsync(readDoc.SelfLink, Resource.LoadFrom<Document>(memoryStream));
            }
        }
