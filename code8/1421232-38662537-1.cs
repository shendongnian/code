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
            var fullPayTax =
                _taxBrackets.Where(t => t.High < _taxableIncome)
                    .Select(t => t)
                    .ToArray()
                    .Sum(taxBracket => (taxBracket.High - taxBracket.Low)*taxBracket.Rate);
            var partialTax =
                _taxBrackets.Where(t => t.Low <= _taxableIncome && t.High >= _taxableIncome)
                    .Select(t => (_taxableIncome - t.Low)*t.Rate)
                    .Single();
            return fullPayTax + partialTax;
        }
    }
