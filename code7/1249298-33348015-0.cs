    public class Features
    {
        public int forecast10day { get; set; }
    }
    
    public class Response
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Features features { get; set; }
    }
    
    public class Forecastday
    {
        public int period { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string title { get; set; }
        public string fcttext { get; set; }
        public string fcttext_metric { get; set; }
        public string pop { get; set; }
    }
    
    public class TxtForecast
    {
        public string date { get; set; }
        public List<Forecastday> forecastday { get; set; }
    }
    
    public class Date
    {
        public string epoch { get; set; }
        public string pretty { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int yday { get; set; }
        public int hour { get; set; }
        public string min { get; set; }
        public int sec { get; set; }
        public string isdst { get; set; }
        public string monthname { get; set; }
        public string monthname_short { get; set; }
        public string weekday_short { get; set; }
        public string weekday { get; set; }
        public string ampm { get; set; }
        public string tz_short { get; set; }
        public string tz_long { get; set; }
    }
    
    public class High
    {
        public string fahrenheit { get; set; }
        public string celsius { get; set; }
    }
    
    public class Low
    {
        public string fahrenheit { get; set; }
        public string celsius { get; set; }
    }
    
    public class QpfAllday
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }
    
    public class QpfDay
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }
    
    public class QpfNight
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }
    
    public class SnowAllday
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }
    
    public class SnowDay
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }
    
    public class SnowNight
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }
    
    public class Maxwind
    {
        public int mph { get; set; }
        public int kph { get; set; }
        public string dir { get; set; }
        public int degrees { get; set; }
    }
    
    public class Avewind
    {
        public int mph { get; set; }
        public int kph { get; set; }
        public string dir { get; set; }
        public int degrees { get; set; }
    }
    
    public class Forecastday2
    {
        public Date date { get; set; }
        public int period { get; set; }
        public High high { get; set; }
        public Low low { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string skyicon { get; set; }
        public int pop { get; set; }
        public QpfAllday qpf_allday { get; set; }
        public QpfDay qpf_day { get; set; }
        public QpfNight qpf_night { get; set; }
        public SnowAllday snow_allday { get; set; }
        public SnowDay snow_day { get; set; }
        public SnowNight snow_night { get; set; }
        public Maxwind maxwind { get; set; }
        public Avewind avewind { get; set; }
        public int avehumidity { get; set; }
        public int maxhumidity { get; set; }
        public int minhumidity { get; set; }
    }
    
    public class Simpleforecast
    {
        public List<Forecastday2> forecastday { get; set; }
    }
    
    public class Forecast
    {
        public TxtForecast txt_forecast { get; set; }
        public Simpleforecast simpleforecast { get; set; }
    }
    
    public class MainModel
    {
        public Response response { get; set; }
        public Forecast forecast { get; set; }
    }
