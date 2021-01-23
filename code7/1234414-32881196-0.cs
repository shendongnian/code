     using Raven.Client;
     using Raven.Client.Extensions;
    
     using (DocumentStore store = new DocumentStore()
     {
         Url = "http://localhost:8080/" ;
     })
     {
         store.Initialize();
        store.DatabaseCommands.EnsureDatabaseExists("SomeDatabase");
    }
