        public decimal RemoveDecimalPoints(decimal d)
        {
            try
            {
                return d * Convert.ToDecimal(Math.Pow(10, (double)BitConverter.GetBytes(decimal.GetBits(d)[3])[2]));
            }
            catch (OverflowException up)
            {
                // unable to convert double to decimal
                throw up; // haha
            }
        }
