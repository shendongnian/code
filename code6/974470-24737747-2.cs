            static void Main(string[] args)
            {
                //MAIN THREAD BOUNDS
                //LAUNCH THE TASK AND GO AHEAD
                var task = Task.Run(() => (EDIT)
                {    
                    //SECOND THREAD BOUNDS 
                    while (true)
                    {
                      ...
                    }
                   //--------------
                });
                task.Wait(); (EDIT) //WAIT FOR TASK COMPLETION  !!!!
                //NOTHING MORE TO DO, SO EXIT APP AND KILL Task.Run THREAD
            }
