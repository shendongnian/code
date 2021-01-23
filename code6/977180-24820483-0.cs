    ctor(decimal grossAmount, taxRateCalculator, itemCategory)
    {
      // store the ctor args as member variables
      recalculate();
    }
    
    public decimal GrossAmount { get { return _grossAmount, } }
    
    private decimal TaxRate { get { return _taxRate ; } } 
    
    public decimal TaxAmount { get { return _grossAmount ; } }
    
    public decimal NetAmount { get { return _netAmount  ; } }
    
    public void recalculate();
    {
       _grossAmount = grossAmount;
       _taxRate = _taxRateCalculater.GetTaxRateFor(_itemCategory);// expensive calculation
       _taxAmount  = _grossAmount  * _taxRate ;
       _netAmount  = _grossAmount  - _taxRate;
    }
    
