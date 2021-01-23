            String number = "1512421.512\n";
            double res;
            if (double.TryParse(number.Substring(0, number.Length - 1), out res))
            {
                Console.WriteLine("It's a number! " + res);
            }
