    public Person this[int indexes]
    {
        get
        {
            bool isFound = false;
            foreach (Person item in per)
            {
                if (item.Age == indexes)
                {
                    return item;
                }                   
            }
            return null;
        }
        set
        {
            per[indexes] = value;
        }
    }
