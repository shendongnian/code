    public bool _shouldCalculate;
    
    public void Producer()
    {
        _shouldCalculate = true;
    }
    
    public async Task Consumer()
    {
        while (true)
        {
            if (!_shouldCalculate)
            {
                await Task.Delay(1000);
            }
            else
            {
                _shouldCalculate = false;
                Calculate();
                
            }
        }
    }
