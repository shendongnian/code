    public void Run(Func<int, Foo> getItem)
    {
        while(true)
        {
            int id;
            string name;
            // some code goes here that gets the value of id 2
            id = 2;
            var item = getItem(id);
            // reference System.Linq
        }
    }
