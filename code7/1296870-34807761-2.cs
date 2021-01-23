    for (i = 10; i <= dataperlines.Count(); i--)
            {
                string[] numbersperrow = dataperlines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (j =10; j <= numbersperrow.Count(); j--)
                {
                    numbers = int.Parse(numbersperrow[j]);
                    reversedarray[i, j] = numbers;
                    Console.Write(numbers + " ");
                }
                Console.WriteLine();
            }
