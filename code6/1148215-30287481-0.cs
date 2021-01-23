    public void MyMethod()
    {
        var p = this.dsLists[2];
        this.f(p);
    }
    private void f(IObsColD p)
    {
        if (p is ObsColD<DSection5>)
        {
            foreach (var item in (ObsColD<DSection5>)p)
            {
            }
        }
        else if (p is ObsColD<DSection4>)
        {
            foreach (var item in (ObsColD<DSection4>)p)
            {
            }
        }
    }
