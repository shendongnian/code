        public class Times {
        public enum : int City {
            LONDON,
            NEW_DEHLI,
            OTHER_PLACE
        };
        public /*DateTime*/double GetTime(City) {
            switch(City) {
                case City.NEW_DEHLI:
                return getDehliTime();
            case City.London:
                return getLondonTime();
            default:
                return DateTime.Now;
            }
        } 
    }
