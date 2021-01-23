    public void CallMethod(dynamic d, string n)
        {
            d.GetType().GetMethod(n).Invoke(d, null);
        }
     
