            string[] array = { "one", "two", "three" };
            string[] arrayFor2 = new string [50];
            string[] arrayFor3 = new string[50];
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i].StartsWith("t") && array[i].EndsWith("o"))
                {
                    //Will print out two
                    Console.WriteLine($"{array[i]}");
                    //Assigns "two" value into new array so you can use elsewhere
                    arrayFor2[i] = array[i];
                }
               [else  if (array\[i\].StartsWith("t") &&][1] array[i].EndsWith("e"))
                {
                    //Will print out three
                    Console.WriteLine($"{array[i]}");
                    //Assigns "three" value into new array so you can use elsewhere 
                    arrayFor3[i] = array[i];
                }
                
            }
            //Elsewhere:
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{arrayFor2[i]}");
                Console.WriteLine($"{arrayFor3[i]}");
            }
            ReadKey();
