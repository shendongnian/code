    public static bool Validate(int adults, int children, int singleMoto, int doubleMoto)
        {
            var childSeats = doubleMoto;
            var adultSeats = doubleMoto * 2 + singleMoto;
            if (children > childSeats)
            {
                return false;
            }
            adultSeats -= children;
            return adults == adultSeats;
        }
