    private void Process()
        {
            
            Dictionary<String, List<string>> dict = new Dictionary<String, List<string>>();
            
            for (int i = 1; i < datarr.Length - 1; i++)
            {
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
