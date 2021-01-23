    List<vw_ServiceandProduct> lstsapm = new List<vw_ServiceandProduct>();
    lstsapm = (from a in db.vw_ServiceandProduct where a.IsActive == true && a.BranchID == Common.BranchID select a).ToList();
    //Session["lstsapmsession"] = lstsapm;
    string key = Guid.NewGuid().ToString("N");
    string path = Server.MapPath("~/App_Data/TempFiles/" + key);
    DataContractSerializer dcs = new DataContractSerializer(typeof(List<vw_ServiceandProduct>));
    using (var outStream = File.OpenWrite(path))
    {
        using (XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateTextWriter(outStream, Encoding.UTF8))
        {
            dcs.WriteObject(xdw, lstsapm);
        }
    }
    // pass key to parent using querystring or cookie
    // Parent page Code:
    string key = ""; // from cookie or querystring
    List<vw_ServiceandProduct> lstsapm = null; //Session["lstsapmsession"] as List<vw_ServiceandProduct>;
    string path = Server.MapPath("~/App_Data/TempFiles/" + key);
    DataContractSerializer dcs = new DataContractSerializer(typeof(List<vw_ServiceandProduct>));
    using (var inStream = File.OpenRead(path))
    {
        using (XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(inStream, new XmlDictionaryReaderQuotas()))
        {
            lstsapm = dcs.ReadObject(xdr) as List<vw_ServiceandProduct>;
        }
    }
    if (lstsapm != null)
    {
        GridView1.DataSource = lstsapm;
        GridView1.DataBind();
    }
