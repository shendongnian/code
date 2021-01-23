    public class MyDataModel
    {
        public string MyComplexProp {get; set;}
    
        //Include a default constructor
        public MyDataModel()
        {
        }
    
        //Include a default constructor
        public MyDataModel(DataClass data)
        {
            MyComplexProp = data.SomeProp.HasValue ? data.OtherProp.Name + " " + data.AnotherProp.Mark : data.EvenAnotherProp.Name,
        }
    }
