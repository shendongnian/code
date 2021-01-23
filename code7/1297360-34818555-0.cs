    public class ExcelImportRow
    {
        public string SalaryString { get; set; }
        /* if zero is ok */
        public double Salary
        {
            get
            {
                double returnValue = 0.00D;
                if (!string.IsNullOrEmpty(this.SalaryString))
                {
                    double.TryParse(this.SalaryString, out returnValue);
                }
                return returnValue;
            }
        }
        public string TaxRateString { get; set; }
        /* if zero is not ok */
        public decimal? TaxRate
        {
            get
            {
                decimal? returnValue = null;
                if (!string.IsNullOrEmpty(this.TaxRateString))
                {
                    decimal tryParseResult;
                    if (decimal.TryParse(this.TaxRateString, out tryParseResult))
                    {
                        returnValue = tryParseResult;
                    }
                }
                return returnValue;
            }
        }
    }
