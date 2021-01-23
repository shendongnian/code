            static void Main(string[] args)
            {
                //MAIN THREAD BOUNDS
                //LAUNCH THE TASK AND GO AHEAD
                Task.Run(() =>
                {    
                    //SECOND THREAD BOUNDS 
                    while (true)
                    {
                      ...
                    }
                   //--------------
                });
                //NOTHING MORE TO DO, SO EXIT APP AND KILL Task.Run THREAD
            }
