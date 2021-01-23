    foreach (var item in Bytelist)
                    {
                        //If seen before ignore
                        if (myHash.Length == item.Length)
                        {
                            bool isequal = true;
                            for (int i = 0; i < myHash.Length; i++)
                            {
                                if (myHash[i] != item[i])
                                {
                                    isequal = false;
                                }
                            }
                            if (isequal)
                            {
                                return true;
                            }
                            
                        }                   
                    }
