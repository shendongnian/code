    public class VatCalculator : IVatCalculator
    {
        private readonly IVatRepository vatRepository;
        public VatCalculator(IVatRepository vatRepository)
        {
            if(vatRepository == null)
                throw new ArgumentNullException(nameof(vatRepository));
            this.vatRepository = vatRepository;
        }
        public decimal Calculate(decimal value, Country country) 
        {
            decimal vatRate = vatRepository.GetVatRateForCountry(country);
            return vatAmount = value * vatRate;
        }
    }
