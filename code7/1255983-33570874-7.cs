    private void Process()
        {
            
            Dictionary<String, List<string>> dict = new Dictionary<String, List<string>>();
            
            for (int i = 0; i < numOfRec - 1; i++)
            {
                //Code to Read record at index i into dataarr.
                String type = datarr[3].Trim();
                String id = datarr[1].Trim();
                if (!dict.ContainsKey(type))
                {
                    dict.Add(type, new BaseList<string>());
                }
                dict[type].Add(id);
            }
        }
    }
