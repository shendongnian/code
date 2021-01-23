    private CostumeLOD _onCostumeLOD;
    public event CostumeLOD OnCostumeLOD
    {
        add
        {
            CostumeLOD costumeLOD01 = this._onCostumeLOD;
            CostumeLOD costumeLOD02;
            do
            {
                costumeLOD02 = costumeLOD01;
                costumeLOD01 = Interlocked.CompareExchange(ref this._onCostumeLOD, (CostumeLOD)Delegate.Combine(costumeLOD02, value), costumeLOD01);
            }
            while (costumeLOD01 != costumeLOD02);
        }
        remove
        {
            CostumeLOD costumeLOD01 = this._onCostumeLOD;
            CostumeLOD costumeLOD02;
            do
            {
                costumeLOD02 = costumeLOD01;
                costumeLOD01 = Interlocked.CompareExchange(ref this._onCostumeLOD, (CostumeLOD)Delegate.Remove(costumeLOD02, value), costumeLOD01);
            }
            while (costumeLOD01 != costumeLOD02);
        }
    }
