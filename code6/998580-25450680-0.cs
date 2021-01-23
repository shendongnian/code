    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
            {
                // Get the unique identifier for this asynchronous operation.
                 String token = (string) e.UserState;
    
                if (e.Cancelled)
                {
                     Console.WriteLine("[{0}] Send canceled.", token);
                }
                if (e.Error != null)
                {
                     Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
                } else
                {
                    Console.WriteLine("Message sent.");
                }
            }
