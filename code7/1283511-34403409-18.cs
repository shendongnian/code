    using System;
    using System.Collections.Generic;
    
    namespace SO1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string BaseUri = "http://api.nytimes.com/svc/books/v3/lists/names.json?api-key=7bb034b7693d6f9753b2f68e00b98c78%3A16%3A73599437";
    
                IEntities entity = new GetCategory(BaseUri);
    
                List<Model.Result> listBookCategory = new List<Model.Result>();
    
                listBookCategory = entity.BookCategory();
    
                foreach (Model.Result r in listBookCategory)
                {
                    Console.WriteLine();
                    Console.WriteLine("...List Name             : " + r.list_name);
                    Console.WriteLine("...Display Name          : " + r.display_name);
                    Console.WriteLine("...List Name Encoded     : " + r.list_name_encoded);
                    Console.WriteLine("...Oldest Published Date : " + r.oldest_published_date);
                    Console.WriteLine("...Oldest Published Date : " + r.newest_published_date);
                    Console.WriteLine("...Updated               : " + r.updated);
                    Console.WriteLine();
                }
            }
        }
    }
