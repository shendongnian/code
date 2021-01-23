    class OutputBackgroundConverter
    {
        public static SolidColorBrush Convert(Severity severity)
        {
            string bgColor = "d3d3d3"; //Gray;
    
            switch (severity)
            {
                case Severity.CRITIC:
                    bgColor = "27ae60"; //carrot orange
                    break;
                case Severity.DEBUG:
                    bgColor = "3498db"; //peter river blue
                    break;
                case Severity.ERROR:
                    bgColor = "e74c3c"; //alizarin red
                    break;
                case Severity.MESSAGE:
                    bgColor = "95a5a6"; //concrete grey
                    break;
                case Severity.WARNING:
                    bgColor = "9b59b6"; //amethyst purple
                    break;
            }
    
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + bgColor));
    
            return brush;
        }
    
    }
