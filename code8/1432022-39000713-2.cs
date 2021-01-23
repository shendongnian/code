    class InputValidator
    {
        public string Input { get; set; }
        public bool IsValidInput { get; set; }
        public bool IsAboveThreshHold { get; set; }
        public bool IsNumber { get; set; }
        public double Litres { get; set; }
        public ValidationResult() { }
        public ValidationResult(string text)
        {
            double litres; Input = text;
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
                Console.WriteLine($"\n\t {Input} is not a valid number \n\n");
                Console.Write("Please re-enter a number greater than 20 : ");                
                return;
            }
            if(!IsAboveThreshHold)
            {
                Console.WriteLine($"\n\t {Input} is below the minimum value of 20  \n\n");
                Console.Write("Please re-enter a number greater than 20 : ");
            }
        }
    }
