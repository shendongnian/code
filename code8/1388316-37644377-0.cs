    int n;
            int t = 0;
            Console.Write("How many elements do you want to add? ");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] List = new int[length];
            while (t < length)
            {
                Console.Write("Enter {0} element value: ", t);
                n = Convert.ToInt32(Console.ReadLine());
                List[t] = n;
                ++t;
            }
            /////V The Below code is skipped for some reason V\\\\\
            int temp;
            int min = List[1];
            int min_i = 1;
            if (length < 2) { Console.WriteLine("Sorry, You can't sort a short    list!"); }
            else
            {
                for (int y = 1; y <= length - 1; y++) //see #1 and #2
                {
                    for (int x = min_i - 1; x >= 0; x--) //for loop was backwards see #2
                    {
                        if (List[min_i] < List[x])
                        {
                            temp = min;
                            List[min_i] = List[x];
                            List[x] = temp;
                        }
                        else break;
                    }
                    //remove y++; and added to for loop
                    min = List[y];
                    min_i = y - 1;
                }
            }
            for (int z = 0; z <= length - 1; z++) //see #1 and #2
            {
                Console.Write(List[z] + " ");
            }
            Console.Read(); //added to prevent the program from closing until you press enter or manually close it
