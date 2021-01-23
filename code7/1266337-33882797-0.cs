                try
                {
                    userChoice = Convert.ToInt16(userChoiceSTR); 
                    Options();
                }
                catch
                {
                    Console.WriteLine("Did not put valid value. Please Select a menu: ");
                    Main_Menu();
                }
