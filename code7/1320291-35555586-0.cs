    // File : MyTableClass_Extend.cs
    public partial class MyTableClass
    {
        public TimeSpan Duration
        {
           get
           {
              TimeSpan ts =(TimeSpan) (EndDateTime - StartDateTime);
              return ts;
           }
        }
    }
