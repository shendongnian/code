      public static class ValueExtensions() {
        public static int ActualValue(this CardValue value) { 
          if (value == CardValue.Ace)
            return 11; // Ace is 11
          else
            return (int) value;
        } 
      }
