    public void ClosedHandler(....)
    {
        MyForm f = sender as MyForm
        if(f!=null)
        {
            Person p = new Person()
            {
                FirstName = f.FirstName;
                LastName = f.LastName;
            };
        }
        
    }
