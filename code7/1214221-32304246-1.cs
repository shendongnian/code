    public class SliderToContentConverter:IValueConverter
    {
      ....Convert(object value,...)
      {
         var slider =value as slider;
         if(slider!=null)
         {
          double min = slider.LowerValue;
          double max = slider.UpperValue;
          if (min == 1) 
             { return "24:00:00"; }
          else
             { return TimeSpan.FromHours(min).ToString(@"hh\:mm\:ss"); }
          if (max == 1) 
             { return "24:00:00"; }
          else {  return TimeSpan.FromHours(max).ToString(@"hh\:mm\:ss"); 
          }
         return null;
       }
    }
