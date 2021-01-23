    List<CariHesapEkstre> senderExtractList = GetExtractList((IList)detayManager.GetMutabakatDetayListByMutabakat(oMutabakat, true));
    
            private List<CariHesapEkstre> GetExtractList(IList tempList) 
            {
                List<CariHesapEkstre> returnList = new List<CariHesapEkstre>();
    
                foreach (var item in tempList)
                {
                    CariHesapEkstre extract = new CariHesapEkstre();
                    foreach (PropertyInfo prop in item.GetType().GetProperties())
                    {
                        foreach (PropertyInfo prop2 in extract.GetType().GetProperties())
                        {
                            if (prop2.Name == prop.Name)
                            {
                                prop2.SetValue(extract, prop.GetValue(item));
                            }
                        }
                    }
    
                    returnList.Add(extract);
                }
    
                return returnList;
            }
