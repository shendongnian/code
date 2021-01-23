            int numbers;
            int[,] dataarray = new int[10,10];
            string[] dataperlines = data.Split(new[] { '\r','\n' },StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i<=dataperlines.Count()-1; i++)
            {
                string[] numbersperrow = dataperlines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j=0; j<=numbersperrow.Count()-1; j++)
                {
                    numbers = int.Parse(numbersperrow[j]);
                    dataarray[i, j] = numbers;
                    Console.Write(numbers + " ");
                }
                Console.WriteLine();
            }
