    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class StartRecord
        : INotifyRead
    {
      [FieldFixedLength(2)]
      public string PostType;
      ...
      // Field hidden to the lib
      [FieldHidden]
      public string Source;
      public void BeforeRead(BeforeReadEventArgs e)
      {
          this.Source = e.RecordLine;
      }
      public void AfterRead(AfterReadEventArgs e)
      {   
      }
    }
