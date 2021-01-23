    Console.Write("Class = ");
            Convert.ToString(Console.ReadLine());
            Console.Write("Number of students = ");
            int aantalStudenten = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            // 2 ask for the names
            string[] namen = new string[aantalStudenten];
            int[] cijfers = new int[aantalStudenten];
            Random RandomNumber = new Random();
            for (int i = 0; i < aantalStudenten; i++){
                Console.Write("Geef naam van de {0}e student : ", i + 1);
                 namen[i] = Convert.ToString(Console.ReadLine());
            }
            Console.WriteLine();
            // 3 give the grade of each student by the name                      
            for (int i = 0; i < aantalStudenten; i++){
                Console.Write("Cijfer van {0} : ", namen[i]);     // here i need the students name)//
                cijfers[i] = Convert.ToInt32(Console.ReadLine());
            }
            double gemiddeld = 0;
            //class avarege here
            for (int i = 0; i < cijfers.Count(); i++) {
                gemiddeld += cijfers[i];
            }
            gemiddeld = gemiddeld / cijfers.Count();
            Console.WriteLine("Het gemiddelde van de klas is: {0}", gemiddeld);
            //highest grade of the class
            int hoogste = 0;
            for (int i = 0; i < cijfers.Count(); i++) {
                if (cijfers[i] > hoogste) {
                    hoogste = cijfers[i];
                }
            }
            Console.WriteLine("De hoogste cijfer is {0}",hoogste);
            //name and grade of each student
            Console.WriteLine();
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
