        static double InputFuel()
        {
            var result = new InputValidator();
            Console.Write("Enter amount of fuel used in litres : ");
            //Check if fule entered is greater than 20, if not ask again
            while (!result.IsValidInput)
            {
                var text = Console.ReadLine();
                result = new InputValidator(text);
                if (!result.IsValidInput) result.ShowErrorMessage();                    
            }
            return result.Litres;
        }
