    public class SomeType
    {
      public int SomeID { set; get; }
      public string someIDStr
      {
        get { return this.SomeID.ToString(); }
      }
    }
    Expression<Func<SomeType, bool>> filterExpression = item => item.someIDStr.Contains("23");
