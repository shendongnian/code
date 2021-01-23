    public List<double> filterlist(List<double> lst)
            {
                List<double> lstDouble = new List<double>();
    
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lstDouble.Contains(lst[i]))
                    {
                        lstDouble.Add(0);
                    }
                    else
                    {
                        lstDouble.Add(lst[i]);
                    }
                }
                return lstDouble;
            }
