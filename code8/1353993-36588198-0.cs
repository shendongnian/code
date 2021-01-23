            Console.WriteLine("Enter Zip Code");
            try
            {
                ziporpostalcode = int.Parse(Console.ReadLine());
                Console.WriteLine("You Enter {0}", ziporpostalcode);
            }
            catch (Exception) {
                Console.WriteLine("Error Occured, Enter only Number");
            }
            
            Console.ReadLine();
