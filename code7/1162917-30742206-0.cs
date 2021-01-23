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
                int firstDigit = int.Parse(FourDigitNum.SubString(0,1));
                int secondDigit = int.Parse(FourDigitNum.SubString(1,1));
                int thirdDigit = int.Parse(FourDigitNum.SubString(2,1));
                int fourthDigit = int.Parse(FourDigitNum.SubString(3,1));
                int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
                string reversed = fourthDigit.ToString()  + thirdDigit.ToString()  + secondDigit.ToString()  + firstDigit.ToString();
                string lastCharFirst = fourthDigit.ToString() + firstDigit.ToString() + secondDigit.ToString() + firstDigit.ToString();
                string exchanged = firstDigit.ToString() + thirdDigit.ToString() + secondDigit.ToString() + fourthDigit.ToString();
                Console.WriteLine("The Sum is: {0}", sum);
                Console.WriteLine("The Reversed number is: {0}", reversed);
                Console.WriteLine("The Last Digit is First: {0}", lastCharFirst);
                Console.WriteLine("The Second and Third Digit Exchanged: {0}", exchanged);
            }
        }
    }
