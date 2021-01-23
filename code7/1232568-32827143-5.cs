     public static class DayOfWeekExtensions {
       public static DayOfWeekShift(this DayOfWeek value, int shift) {
         return (DayOfWeek) ((((int)value + shift) % 7 + 7) % 7);
       }
     }
    
     ...
     
     var result = _RESETDAY.Shift(1);
