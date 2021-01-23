                    Board();// calling the board Function
    
                    if (task.Status != TaskStatus.Running)
                    {
                        task.Start();
                    }
    
                    choice = int.Parse(Console.ReadLine());//Taking users choice  
