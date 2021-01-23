    namespace Extensions
    {
        public static class Extensions
        {
            public static string Ordinal(this int Number)
            {
                string Str = Number.ToString();
                Number = Number % 100;
                if ((Number >= 11) && (Number <= 13))
                {
                    Str += "th";
                }
                else
                {
                    switch (Number % 10)
                    {
                        case 1:
                            Str += "st";
                            break;
                        case 2:
                            Str += "nd";
                            break;
                        case 3:
                            Str += "rd";
                            break;
                        default:
                            Str += "th";
                            break;
                    }
                }
                return Str;
            }
        }
