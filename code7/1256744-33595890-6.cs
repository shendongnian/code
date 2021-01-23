     int[] inputs = new int[13]; // here you have inputs
                for(int i=0;i<13;i++)
                {
                    Console.WriteLine("Please gimme number "+ (i+1));
                    int value;
                    value = int.Parse(Console.ReadLine());
                    inputs[i] = value;
                }
