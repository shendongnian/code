                Console.Write("Are there any additional crates y/n? ");
                char a = new char();
                a = char.Parse(Console.ReadLine());
                dim l as new List(Of double)()
                dim w as new List(Of double)()
                dim h as new List(Of double)()
                char y = default(char);
                while (a == y)  '' Revise this condition as it takes `a` input once and keep looping on it, instead it should take input always unless user enters `n`
                {
                    //Crate Dimensions Entered
                    Console.WriteLine("Please enter the crate Length for your incoming shipment: ");
                    l.Add(double.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter the crate Width for your incoming shipment: ");
                    w.Add(double.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter the crate Height for your incoming shipmet");
                    h.Add(double.Parse(Console.ReadLine()));
                }
