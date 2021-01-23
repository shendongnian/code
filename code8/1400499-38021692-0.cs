    public class TextData
        {
            public ObjectId _id { get; set; }
            public string read { get; set; }    
        }
    
        public class Processor
        {
            public async void ProcessData()
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("test");
      
                var collection = database.GetCollection<TextData>("Yogevnn");
                var readingflag = false;
                var listOfDocument = new List<TextData>();
                var limiAtOnce = 100;
                var current = 0;
    
                foreach (var line in File.ReadLines(@"E:\file.txt"))
                {
                    if (readingflag)
                    {                        
                        var dataToInsert = new TextData {read = line};
                        listOfDocument.Add(dataToInsert);
                        readingflag = false;
                        Console.WriteLine($"Current position: {current}");    
                        if (++current == limiAtOnce)
                        {
                            current = 0;
                            Console.WriteLine($"Inserting data");
                            var listToInsert = listOfDocument;
    
                            var t = new Task(() => {
                                Console.WriteLine($"Inserting data START");
                                collection.InsertManyAsync(listToInsert);
                                Console.WriteLine($"Inserting data FINISH");
                            }
    
                            
                      );
                            t.Start();
                            listOfDocument = new List<TextData>();
                        }
                    }
                    else
                    {
                        readingflag = true;
                    }
                }
    
                // insert remainder
                await collection.InsertManyAsync(listOfDocument);
            }
        }
