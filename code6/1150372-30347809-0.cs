    public void Reset()
    {
        var originalValue=_bar;
        var replaced=Interlocked.CompareExchange(ref _bar,new T(),originalValue);
        if(replaced!=_bar)
        {
            //We got to replace the value, 
            //we could dispose it safely if we wanted to
            if (replaced!=null) 
            {
               replaced.Dispose();
            }
        }
    }
