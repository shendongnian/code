    //-----METHODS
            //VARIABLES
            double inchFeet;
            int wholeFeet;
        public double GetHeightFeet()
        {
            //CENTIMETERS TO FEET
            //PlayerHeight is ___cm input
            inchFeet = (PlayerHeight / 0.3048) / 100;
            //LEFT PART BEFORE DECIMAL POINT. WHOLE FEET
            wholeFeet = (int)inchFeet;
            return wholeFeet;
        }
        public double GetHeightInches()
        {
            //DECIMAL OF A FOOT TO INCHES TEST HEIGHT 181cm to see if 11''
            double inches = Math.Round((inchFeet - wholeFeet) / 0.0833);
            return inches;
        }
