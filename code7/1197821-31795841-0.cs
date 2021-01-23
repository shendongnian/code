      //HAPPY NUMBER
            //return true if 'number' is a happy number.
           private static bool isHappy(int number)
            {
                HashSet<int> sumArray = new HashSet<int>();
                while (true)
                {
                    int result = sumPowered(number, 2);
                    if (result == 1)
                    {
                        return true;
                    }
                    else if (sumArray.Contains(result))
                    {
                        return false;
                    }
                    number = result;
                    sumArray.Add(result);
                }
           }
