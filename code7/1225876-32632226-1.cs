    public class MyTargetModel
    {
        public string FirstName { get; set; }
    }
    
    public string Post(MyTargetModel model)
    {
        var first = model.FirstName;
        //for every supported field.
    }
