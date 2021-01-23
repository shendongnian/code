    public class MyErrorLog
    {
       public List<BLLLog> Logs{get;set;}
    }
    var BLTemp = new MyErrorLog();
    BLTemp.Logs = new List<BLLLog>();
    var log = new BLLLog();
    log.DateTime = DateTime.Now;
    log.Event = "DB Not Access";
    log.EventCode = (int)LogValues.DataBaseNotAccess;
    log.ID = 0;
    log.IpAddress = Core.GetIPAddress();
    BLTemp.Logs.Add(log);
       XmlSerializer serializer = new XmlSerializer(typeof(MyErrorLog));
                    StreamWriter xmlError = new StreamWriter(string.Concat(Server.MapPath("/"), "\\Sitemap\\XMLErrors.xml"),true);
                    serializer.Serialize(xmlError,BLTemp);
                    xmlError.Close();
    StreamReader xmlError = new StreamReader(string.Concat(Server.MapPath("/"), "\\Sitemap\\XMLErrors.xml"));
                        XmlSerializer serializer = new XmlSerializer(typeof(MyErrorLog));
                        MyErrorLog listLog = (MyErrorLog)serializer.Deserialize(xmlError);
                        xmlError.Close();
