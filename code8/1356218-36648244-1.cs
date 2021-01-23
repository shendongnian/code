    public class MyPageValues
    {
        public string Value1 {get;set;}
        public string Value2 {get;set;}
        public MyPageValues(){} //default constructor
        public MyPageValues(System.Web.UI.StateBag viewState)
        {
            Value1 = (string)viewState["Value1"];
            Value2 = integer.Parse(viewState["Value2"]); //Do some better checking.
        }
    }
