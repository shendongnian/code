        private int Sum()
        {
            //myrichtextbox is your rich control
            string myText = myrichtextbox.Text;
            var separators = new string[] { "\n" };
            var myNumbers = myText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    
            int sum = 0;
    
            foreach (var num in myNumbers)
            {
                int convertedNumber;
                if (Int32.TryParse(num, out convertedNumber))
                    sum += convertedNumber;
            }
    
            return sum;
        }
