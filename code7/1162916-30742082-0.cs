    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication6
    {
    class Program
    {
        static void Main(string[] args)
        {
            string FourDigitNum = Console.ReadLine();
            List<string> digitsList = new List<string>();
            foreach (char c in FourDigitNum)
            {
                digitsList.Add(c.ToString());
            }
            string[] digits = digitsList.ToArray();
            int firstDigit = int.Parse(digits[0]);
            int secondDigit = int.Parse(digits[1]);
            int thirdDigit = int.Parse(digits[2]);
            int fourthDigit = int.Parse(digits[3]);
            int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
            string reversed = digits[3] + digits[2] + digits[1] + digits[0];
            string lastCharFirst = digits[3] + digits[0] + digits[1] + digits[0];
            string exchanged = digits[0] + digits[2] + digits[1] + digits[3];
            Console.WriteLine("The Sum is: {0}", sum);
            Console.WriteLine("The Reversed number is: {0}", reversed);
            Console.WriteLine("The Last Digit is First: {0}", lastCharFirst);
            Console.WriteLine("The Second and Third Digit Exchanged: {0}", exchanged);
        }
    }
}
