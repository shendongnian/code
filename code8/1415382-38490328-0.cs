     if (Bytelist.Count != 0)
            {
                foreach (var item in Bytelist)
                {                    
                    if (myHash.Length == item.Length)
                    {
                        for (int i = 0; i < myHash.Length; i++)
                        {
                            if (myHash[i] != item[i])
                            {
                                return false;
                            }
                        }
                        return true;
                    }                   
                }
            }
