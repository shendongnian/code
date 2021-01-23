       /*Assign Initial Value*/
            int highestNum = numberArray[0];
            int lowestNum = numberArray[0];
            int sum = 0;
    
            foreach (int item in numberArray)
            {
                /*Get The Highest Number*/
                if (item > highestNum)
                {
                    highestNum = item;
                }
                /*Get The Lowest Number*/
                if (item < highestNum)
                {
                    lowestNum = item;
                }
                //get the sum
                sum = item + sum;
            }            
            
            //display the Highest Num
            Console.WriteLine(highestNum);
            //display the Lowest Num
            Console.WriteLine(lowestNum);
            //Display The Average up to 2 decimal Places
            Console.WriteLine((sum/numberArray.Length).ToString("0.00"));
