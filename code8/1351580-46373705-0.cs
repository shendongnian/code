            for(int i=0;i<list.Count;i++)
            {
                for(int j=0;j<list.Count;j++)
                {
                    if((list[i]+list[j])==12)
                    {
                        return new Tuple<int, int>(i,j);
                    }
                }
            }
            return null;
