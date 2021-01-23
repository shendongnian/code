    public class TaxBracket
    {
        public int Low { get; set; }
        public int High { get; set; }
        public decimal Rate { get; set; }
    }
    public class TaxCalculator
    {
        private readonly int _taxableIncome;
        private readonly TaxBracket[] _taxBrackets;
        public TaxCalculator(int taxableIncome, TaxBracket[] taxBrackets)
        {
            _taxableIncome = taxableIncome;
            _taxBrackets = taxBrackets;
        }
        public decimal Calculate()
        {
            var fullPayBrackets = _taxBrackets.Where(t => t.High < _taxableIncome).Select(t => t).ToArray();
            var fullPayTax = fullPayBrackets.Sum(taxBracket => (taxBracket.High - taxBracket.Low)*taxBracket.Rate);
            var partialTaxBracket =
                _taxBrackets.Where(t => t.Low <= _taxableIncome && t.High >= _taxableIncome).Select(t => t).Single();
            var partialTax = (_taxableIncome - partialTaxBracket.Low)*partialTaxBracket.Rate;
            return fullPayTax + partialTax;
        }
    }
