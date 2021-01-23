        public class DocumentRepository<T> where T : class
        {            
            public static IEnumerable<T> GetDocuments(string docLink)
            {
              //code assumes Client object is instantiated earlier
              var docs = Client.CreateDocumentQuery<T>(docLink).AsEnumerable();
              
              return docs;
            }
        }
