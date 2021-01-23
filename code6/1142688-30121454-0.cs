    public class MyTimeAgoValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            var timeAgo = DateTime.UtcNow - value;
            if (timeAgo.TotalSeconds < 30)
            {
                return "just now";
            }
    
            if (timeAgo.TotalMinutes < 10)
            {
                return "a few minutes ago";
            }
    
            if (timeAgo.TotalMinutes < 60)
            {
                return "in the last hour";
            }
    
            if (timeAgo.TotalMinutes < 24*60)
            {
                return "in the last day";
            }
    
            return "previously";            
        }
    }
