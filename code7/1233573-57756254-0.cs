    #nullable enable
    namespace TestCSharpEight
    {
      public class Developer
      {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public Developer(string fullName)
        {
            FullName = fullName;
            UserName = null;
        }
    }}
