    public bool isDeelverzamelingVan(List<int> eersteVerzameling, List<int> tweedeVerzameling)
    {
        if(eersteVerzameling==null || tweedeVerzameling==null)
        {
            return false;
        }
        foreach (int element in eersteVerzameling)
        {
            if (!tweedeVerzameling.Contains(element))
            {
               return false;
            }         
        }
        return true;
    }
