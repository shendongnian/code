    ////Correct        
            Int32[] arr = { 4, 7, 9, 3, 8, 6, 4, 3, 3, 9 };
            List<Int32> newArr = new List<Int32>();
            Int32 max = arr.Max();
            Int32 min = arr.Min();
            Boolean removeMax = false;
            Boolean removeMin = false;
            foreach (var each in arr)
            {                
                if (each == min || each == max)
                {
                    if (!removeMax || !removeMin)
                    {
                        if (each == min)
                        {
                            newArr.Add(each);
                            removeMin = true;
                        }
                        if (each == max)
                        {
                            newArr.Add(each);
                            removeMax = true;
                        }                        
                    }
                }
                else
                {
                    newArr.Add(each);
                }               
            }
            var arrAfter = newArr.ToArray();           
