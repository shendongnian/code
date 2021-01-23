    namespace MyExtensionMethods
    {
        //MyDataModel sample
        public class MyDataModel
        {
            public int? SomeProp { get; set; }
            public string OtherPropName { get; set; }
            public string AnotherPropMark { get; set; }
            public string EvenAnotherPropName { get; set; }
        }
    
        //The extension Method
        public static class ExtensionMethod
        {
            public static string ToMyComplexProp(this MyDataModel p)
            {
                return p.SomeProp.HasValue ? p.OtherPropName + " " + p.AnotherPropMark : p.EvenAnotherPropName;
            }
        }
    
        public class TestClass
        {
            MyDataModel myDataModel;
            public TestClass()
            {
                myDataModel = new MyDataModel();
                //This is the extension method and it's working
                myDataModel.ToMyComplexProp();
            }
        }
    }
