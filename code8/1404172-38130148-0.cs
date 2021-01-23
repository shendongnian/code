        int currentDigit = 0;
        int[] digits = new int[4];
        public void Key1()
        {
            if (currentDigit==digits.Length-1)
            {
                return; // all digits entered
            }
            digits[currentDigit] = 1;
                        
            displaycode.text = string.Empty;
            for (int i = 0; i < digits.Length; ++i)
            {
                displaycode.text += digits[i];
            }
            switch(currentDigit)
            {
                case 0:
                    print("First digit entered");
                    break;
                case 1:
                    print("2nd digit entered");
                    break;
                // etc
            }
            ++currentDigit;
        }
