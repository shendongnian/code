    public interface IReports
    {
       ShowValue {get;}
    }
    
    public class Students:IReports
    {
        public string Name { get; set; }
        public string ShowValue { get { return Name; } }
    }  
    
    public class Classes : IReports
    {
        public string ClassName { get; set; }
        public string StudentName { get; set; }
        public string ShowValue { get { return ClassName; } }
    }   
    public class Cars : IReports
    {
        public int Mileage { get; set; }
        public string CarType { get; set; }
        public string StudentName { get; set; }
        public string ShowValue { get { return CarType; } }
    }
