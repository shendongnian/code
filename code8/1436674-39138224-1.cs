      [DebuggerDisplay("Values = {DisplayValue}")]
      public struct CommonRow {
        public object[] Values;
        public string DisplayValue
        {
          get
          {
              return Values.Join(",");
          }
        }
      }
