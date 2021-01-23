    public void MyMethod()
    {
        var p = this.dsLists[2];
        this.f(p);
    }
    private void f(IObsColD col)
    {
        if (col is ObsColD<DSection5>)
        {
            foreach (var item in (ObsColD<DSection5>)col)
            {
            }
        }
        else if (col is ObsColD<DSection4>)
        {
            foreach (var item in (ObsColD<DSection4>)col)
            {
            }
        }
    }
