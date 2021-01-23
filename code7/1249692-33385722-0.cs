            List<int> SlotMapLP1 = new List<int>();
            for (int x = 0; x < 25; x++)
            {
                SlotMapLP1.Add(int.Parse(waferArrangement.Substring(x, 1))); //input string contains 1 and 0; where 1 should be max 12 count only
            }
            int i = 0, j = 0, k = 0, waferCount = 0;
            for (i = 0; i < SlotMapLP1.Count; i++ )
                if (SlotMapLP1[i] == 1)
                    waferCount++;
            List<int> ptnOne = new List<int>(SlotMapLP1);
            for (j = 0; j < ptnOne.Count; j++ )
            {
                if(j == 0 || j % 2 == 0)
                {
                    if (ptnOne[j] == 1)
                    {
                        k = j + 1;
                        while (k < ptnOne.Count())
                        {
                            if (ptnOne[k] == 0)
                            {
                                ExtensionMethods.Swap(ptnOne, k, j); //swap position
                                break;
                            }
                            k++;
                        }
                    }
                }
                else
                {
                    if (ptnOne[j] == 0)
                    {
                        k = j + 1;
                        while (k < ptnOne.Count())
                        {
                            if (ptnOne[k] == 1)
                            {
                                ExtensionMethods.Swap(ptnOne, k, j); //swap position
                                break;
                            }
                            k++;
                        }
                    }
                }
            }
