    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CL1));
    var m = new MemoryStream(Encoding.UTF8.GetBytes(@"{""I1"":""test1"",""I2"":""test2""}"));
    var cl1 = ser.ReadObject(m) as CL1; 
    Console.WriteLine(cl1.I1 + " " + cl1.I2);
----
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
