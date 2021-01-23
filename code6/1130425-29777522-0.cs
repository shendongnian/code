    public class MyClass 
    {
      public System.Windows.Size WSize = new System.Windows.Size();
      
      [XmlIgnore]
      public System.Drawing.Size DSize = new Size();
      public int DSizeWidthForSerialization
      {
        get
        {
          return DSize.Width;
        }
        set
        {
          DSize.Width = value;
        }
      }
      public int DSizeHeightForSerialization
      {
        get
        {
          return DSize.Height;
        }
        set
        {
          DSize.Height = value;
        }
      }
    }
