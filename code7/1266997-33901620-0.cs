    internal class Program
    {
        static void Main()
        {
            double d = 21.8786;
            double d1 = 21.000;
            double d2 = 21.02000;
            double d3 = 0;
            WriteNameAndValue(nameof(d), d.FormatDoubleToFourPlaces());
            WriteNameAndValue(nameof(d1), d1.FormatDoubleToFourPlaces());
            WriteNameAndValue(nameof(d2), d2.FormatDoubleToFourPlaces());
            WriteNameAndValue(nameof(d3), d3.FormatDoubleToFourPlaces());
        }
        static void WriteNameAndValue(string name, string value)
        {
            Console.WriteLine($"Name:  {name}\tValue: {value}");
        }
      
    }
     static class DoubleHelper
    {
        public static string FormatDoubleToFourPlaces(this double d, CultureInfo ci = null)
        {
            const int decimalPlaces = 4;
            
            if (double.IsInfinity(d) || double.IsNaN(d))
            {
                var ex = new ArgumentOutOfRangeException(nameof(d), d, "Must not be NaN or infinity");
                throw ex;
            }
            decimal decimalVersion = Convert.ToDecimal(d);
            if (decimalVersion == 0)
            {
                return string.Empty;
            }
            int integerVersion = Convert.ToInt32(Math.Truncate(decimalVersion));
            if (integerVersion == decimalVersion)
            {
                return integerVersion.ToString();
            }
            decimal scaleFactor = Convert.ToDecimal(Math.Pow(10.0, decimalPlaces));
            decimal scaledUp = decimalVersion*scaleFactor;
            decimal truncatedScaledUp = Math.Truncate(scaledUp);
            decimal resultingVersion = truncatedScaledUp/scaleFactor;
            return resultingVersion.ToString(ci ?? CultureInfo.InvariantCulture);
        }
    }
