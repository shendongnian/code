    public abstract class SalesOrderLineRetBase
    {
    }
    public class SalesOrderLineRet : SalesOrderLineRetBase
    {
    }
    public class SalesOrderLineGroupRet : SalesOrderLineRetBase
    {
    }
    public class RootObject
    {
        [XmlElement(typeof(SalesOrderLineRetBase))]
        [XmlElement(typeof(SalesOrderLineRet))]
        [XmlElement(typeof(SalesOrderLineGroupRet))]
        public List<SalesOrderLineRetBase> SalesOrders { get; set; }
    }
