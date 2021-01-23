     static void Main(string[] args)
            {
                using (Entities entities = new Entities())
                {
                    try
                    {
                        //code goes here
                        entities.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        syncResult = string.IsNullOrEmpty(e.Message) ? "Error" : e.Message;
    
                    }
                    entities.LogHistories.Add(new LogHistory() { Description = syncResult });
                    entities.SaveChanges();
                }
            }       
    
