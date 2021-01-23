    private void f(IObsColD p)
    {
        var ds5 = p as ObsColD<DSection5>;
        var ds4 = p as ObsColD<DSection4>;
        if (ds5 != null)
        {
            foreach (var item in ds5)
            {
            }
        }
        else if (ds4 != null)
        {
            foreach (var item in ds4)
            {
            }
        }
    }
