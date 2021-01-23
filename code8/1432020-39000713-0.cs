    class InputValidator
    {
        public bool IsValidInput { get; set; }
        public bool IsAboveThreshHold { get; set; }
        public bool IsNumber { get; set; }
        public double Litres { get; set; }
        public ValidationResult() { }
        public ValidationResult(string text)
        {
            double litres;
            if (double.TryParse(text, out litres))
            {
                Litres = litres;
                IsAboveThreshHold = litres > 20;
                IsNumber = true;                
            }
            IsValidInput = IsNumber && IsAboveThreshHold;
        }
        public void ShowErrorMessage()
        {
            if (!IsNumber)
            {
                Console.WriteLine("\n\t {0} is not a valid number \n\n", Litres);
                Console.Write("Please re-enter a number greater than 20 : ");                
                return;
            }
            if(!IsAboveThreshHold)
            {
                Console.WriteLine("\n\t {0} is below the minimum value of 20  \n\n", Litres);
                Console.Write("Please re-enter a number greater than 20 : ");
            }
        }
    }
