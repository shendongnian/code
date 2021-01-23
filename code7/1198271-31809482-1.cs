    public interface II1
    {
        string I1 { set; get; }
    }
    public interface II2
    {
        string I2 { set; get; }
    }
    public class CL1 : II1, II2
    {
        public string I1 { set; get; }
        public string I2 { set; get; }
    }
