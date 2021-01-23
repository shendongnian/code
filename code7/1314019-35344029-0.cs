    public void SomeMethod()
    {
        Parallel.For(0, 100, i =>
        {
            var data = GetDataFor(i);
            //Do something
        });
    }
    public data GetDataFor(int i)
    {
        //generate data for i
        return data;
    }
