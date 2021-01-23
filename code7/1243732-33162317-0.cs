          static void Main(string[] args)
            {
               Rectangle rect = new Rectangle();
               string errorMessage = String.empty;
               try
               {
                    // Subscribe to the Changed event
                    rect.Changed += new EventHandler(Rectangle_Changed);
                    rect.Length = 10;
                }
                catch(Exception ex)
                {
                     errorMessage = ex.Message;
                }
            }
