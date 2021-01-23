    public enum MyEnum
    {
        NotSet = 0,
        iOS = 1,
        Android = 2
    }
    class MyDisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        public MyDisplayNameAttribute(MyEnum myEnum)
            : base("Is Active in " + myEnum.ToString())
        { 
        }
        public override string DisplayName
        {
            get
            {
                // you could do the "Is Active in " here, but I doubt control frameworks would use it.
                return base.DisplayName;                
            }
        }         
    }
    public class MyModel
    {
        [MyDisplayName(MyEnum.iOS)]
        bool IsActiveApp1 { get; set; }
        [MyDisplayName(MyEnum.Android)]
        bool IsActiveApp2 { get; set; }
    }
