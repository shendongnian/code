    static void Sort(string [] strArray)
        {            
            try
            {
                
                string[] order = new string[strArray.Length];
                string[] sortedarray = new string[strArray.Length];
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] values = strArray[i].ToString().Split('#');                    
                    int index=int.Parse(values[1].ToString()) - int.Parse(values[0].ToString());
                    order[i] = strArray[i].ToString() + "," + index;                    
                }
                for (int i = 0; i < order.Length; i++)
                {
                    string[] values2 = order[i].ToString().Split(',');
                    if (sortedarray[int.Parse(values2[1].ToString())-1] == null)
                    {
                        sortedarray[int.Parse(values2[1].ToString())-1] = values2[0].ToString();
                    }
                    else
                    {
                        if ((int.Parse(values2[1].ToString())) >= sortedarray.Length)
                        {
                            sortedarray[(int.Parse(values2[1].ToString())-1) - 1] = values2[0].ToString();
                        }
                        else if ((int.Parse(values2[1].ToString())) < sortedarray.Length)
                        {
                            sortedarray[(int.Parse(values2[1].ToString())-1) + 1] = values2[0].ToString();
                        }
                    }                    
                }
                for (int i = 0; i < sortedarray.Length; i++)
                {
                    Console.WriteLine(sortedarray[i]);
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
 
            }
