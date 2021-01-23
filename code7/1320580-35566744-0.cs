            String input =Console.ReadLine();
            int nInput;
            int inputLength = input.Length;
            if (int.TryParse(input, out nInput))
            {
                int[] digits = new int[inputLength];
                Array.Reverse(digits);
                Console.WriteLine("Reversed Number is:{0}",String.Join( "",digits));
            }
            else { Console.WriteLine("Wrong input"); }
          
