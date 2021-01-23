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
        [XmlArray("SalesOrders")]
        [XmlArrayItem(typeof(SalesOrderLineRetBase))]
        [XmlArrayItem(typeof(SalesOrderLineRet))]
        [XmlArrayItem(typeof(SalesOrderLineGroupRet))]
        public List<SalesOrderLineRetBase> SalesOrders { get; set; }
    }
