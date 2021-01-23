    public void MyUpdate(MyType foo)
    {
        Thing dummy = something.FirstOrDefault(bar => bar.Stuff.SkipWhile((item) => 
        {
            Data dataRx = item.First;
            if (dataRx != null && dataRx.ID.Equals(globalNonsense.ID))
            {
                dataRx.fooBuddy = foo;
                return false;
            }
            else
            {
                return true;
            }
        }).Count() != 0);
    }
