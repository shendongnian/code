    var list = Vehicles as IList<Vehicles>;
    if(list != null)
    {
        for (int count = 0; count < list.Count; count++)
        {
            if (list[count].Mode)
            {
                // do something with it
            }
        }
    }
    
