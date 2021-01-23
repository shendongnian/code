    [XmlInclude(typeof(Report01)]
    [XmlInclude(typeof(Report02)]
    public class BaseClass { }
    public class Report01 : BaseClass { ... }
    public class Report02 : BaseClass { ... }
    List<BaseClass> objs = new List<BaseClass>();
    List<BaseClass> objs2 = new List<BaseClass>();
    // fill collections here
    ObjectToXml(objs, "c:\\12\\objs.xml");
    ObjectToXml(objs2, "c:\\12\\objs2.xml");
    
