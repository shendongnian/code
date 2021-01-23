        public static String RollNumbers()
        {
            int roll = rnd.Next(1, 100000);
            int lastDigit = roll % 10;
            int secondLastDigit = (roll / 10) % 10;
            if( lastDigit == secondLastDigit )
            {
                return "doubles";
            }
            else
            {
                return "none";
            }
        }
