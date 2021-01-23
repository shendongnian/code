        public static List<ChartPoint> MethodName()
        {
            List<ChartPoint> points = new List<ChartPoint>();
              //Get Your Measured Variables, in a list so you can loop through
              points.Add(new ChartPoint
              {
                   PointValue = measured variable,
                   AxisXText = "Text you want to display"
              });
           return points;
       }            
        
