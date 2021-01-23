    public class TimeSpanWrapper
    {
    
    public TimeSpan Time{get;set;}
    
    public override string ToString()
    {
    return string.Format("{0}:{1}.{2}",Time.Hour,Time.Minute,Time.Second);
    }   
    }
