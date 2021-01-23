        int currentDigit = 0;
        char[] digits = new char[4];
        public void KeyPressed(char keyDigit)
        {
            if (currentDigit==digits.Length-1)
            {
                return; // all digits entered
            }
            digits[currentDigit] = keyDigit;
                        
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
