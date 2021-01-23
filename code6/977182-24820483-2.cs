      ctor(decimal grossAmount, taxRateCalculator, itemCategory)
        {
          // store the ctor args as member variables
          recalculate();
        }
        
        public decimal GrossAmount { get; private set; }
        
        public decimal TaxAmount { get; private set; }
        
        public decimal NetAmount { get; private set; }
        
        public void recalculate();
        {
           // expensive calculation
           var _taxRate = _taxRateCalculater.GetTaxRateFor(_itemCategory);
    
           GrossAmount = grossAmount;
           TaxAmount = GrossAmount * _taxRate ;
           NetAmount = GrossAmount - _taxRate;
        }
