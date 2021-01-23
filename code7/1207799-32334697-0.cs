    public ConfigurationTransaction this[String index]
    {
        get
        {
            foreach (var item in Transactions)
            {
                if (item.type.ToLower().Trim() == index.ToLower().Trim())
                {
                    return item;
                }
            }
            return null;
        }
    }    
