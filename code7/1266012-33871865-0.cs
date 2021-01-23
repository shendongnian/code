        private void Main_Menu()
                {
        
                    Console.WriteLine("1). Welcome");
                    Console.WriteLine("2). Help Facilities");
                Console.WriteLine("3). Exit");
    
                string userChoiceSTR = Console.ReadLine();
    
                if (!string.IsNullOrEmpty(userChoiceSTR))
                {
                    userChoice = Convert.ToInt16(userChoiceSTR);
                    try
                {
                    Options();
                }
                catch
                {
                    Console.WriteLine("Did not put any value. Please Select a menu: ");
                    Main_Menu();
                }
                }
                else {
                    Console.WriteLine("Did not put any value. Please Select a menu: ");
                    Main_Menu();
                }
            }
