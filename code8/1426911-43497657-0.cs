    namespace Bot.Models
    {
        public class Dialog
        {
            internal static string DialogName { get; set; }
            internal static string Culture { get; set; }
            //Returns the rsource file name.culture.resx
            internal static string ResourceFile { get { return $"{System.AppDomain.CurrentDomain.BaseDirectory}Properties\\{DialogName}.
    {Culture}.resx"; } }
        }
    }
