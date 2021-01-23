            string[,] prop; //This is a 2D string
            List<List<string>> mysteryList;
            if (value is object[,])
            {
                object[,] objArray = (object[,])value;
                // Get upper bounds for the array
                int bound0 = objArray.GetUpperBound(0);//index of last element for the given dimension
                int bound1 = objArray.GetUpperBound(1);
                prop = new string[bound0 + 1, bound1 + 1];
                mysteryList = new List<List<string>>();
                for (int i = 0; i <= bound0; i++)
                {
                    var temp = new List<string>();
                    for (int j = 0; j <= bound1; j++)
                    {
                        prop[i, j] = objArray[i, j].ToString();//Do null check and assign 
                        temp.Add(prop[i, j]);
                    }
                    mysteryList.Add(temp);
                }
            }
