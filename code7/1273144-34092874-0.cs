    ArrayList list = new ArrayList();
    
            list.Add("2008");
            list.Add("2009");
    
            ArrayList list2 = new ArrayList();
    
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToString().Contains("2008"))
                {
                    //get the index and add empty items upto the index.
                    // then set the value
                    var indx = 5;
                    for (int j = 0; j < indx + 1; j++)
                    {
                        list2.Add("empty");
                    }
                    list2[indx] = list[i];
    
                }
            }
