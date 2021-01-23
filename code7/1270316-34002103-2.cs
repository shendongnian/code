    public class CarDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    public class ReportDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    
    public class CatSimpleDto
    {
        public CarDto Car { set; get; }
        public ReportDto FirstPost { set; get; }
    }
