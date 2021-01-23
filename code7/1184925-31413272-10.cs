    public Func<int> X()
    {
        {
            var i = 1;
            {
                i++;
                {
                    return () => i;
                }
            }
        }
    }
    public Func<int> Y()
    {
        var i = 1;
        i++;
        return () => i;
    }
