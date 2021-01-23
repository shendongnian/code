    string SubAssemblySerialNumber = form.serail;
    string Refdes = row.Cells["RefDesc"].Value.ToString().Replace(";", "");
    string URL = "http://" + MSSRestSrv + ":8018/Quality/SerialNumbers/BoxBuilds/" + serial + "/Attach/?SubAssemblySerialNumber=" + SubAssemblySerialNumber + "&Refdes=" + Refdes + "";
    try
    {
        using (WebClient client = new WebClient())
        {
            System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
    
            byte[] responsebytes = client.UploadValues(URL, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
        }
    }
    catch (WebException we)
    {
        MessageBox.Show(we.Response.ToString());
    }
