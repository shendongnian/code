    while (numberOfValues < arraySize)
    {
    
           Console.WriteLine("Enter value: ");
           inputValue = Console.ReadLine();
           intValue = Convert.ToInt32(inputValue);
                   
    
           if (intValue >= 1 && intValue <= 10)
           {
                if (!ocurrences.ContainsKey(intValue))
                {
                    ocurrences.Add(intValue, 0);
                }
                values[numberOfValues] = Convert.ToInt32(inputValue);
                numberOfValues++;
                        
                ocurrences[intValue]++;
           }
           else
           {
                 Console.WriteLine("Incorrect value.");
                 incorrectValues++;
    
           }
    }
