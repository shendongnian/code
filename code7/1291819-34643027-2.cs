    Public class DateAndValues
    {
       public DateTime Date {get; set;}
       public Int32 Index {get; set;}
       public Int32 Value1 {get; set;}
       public Int16 Value2 {get; set;}
       public bool ShouldSerializeValue1 ()
       {
          // your condition for serialization, for example even objects:
          this.Index % 2 != 0;
       }
    }
