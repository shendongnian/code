      public static class EnumsChartTypeExtensions {
        //TODO: find out a proper name for the method
        public static Boolean IsOnLine(this Enums.ChartType value) { 
          return value == Enums.ChartType.Answered || 
                 value == Enums.ChartType.Abandoned ||
                 value == Enums.ChartType.ExpectedWait ||
                 value == Enums.ChartType.InQueue; 
        }
      }
