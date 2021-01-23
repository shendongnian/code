    string siteContent = string.Empty;
    string url = "http://www.RESTFEEDURL.com";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using(Stream responseStream = response.GetResponseStream())
    using(StreamReader streamReader = new StreamReader(responseStream))
    {
        siteContent = streamReader.ReadToEnd();
    }
    //NOW PARSE THE DATA AND SEND TO DATABASE HERE
    //data is in siteContent
    //now you want to decode the data and get all the column names
    var keyArray = Ext.Object.getKeys(Ext.JSON.decode(siteContent));
    //if suppose data has following format
    //{"ID":"1","name":"google","IP":"69.5.33.22","active":"true"}
    //{"ID":"2","name":"bing","IP":"70.5.232.33","active":"false"}
    console.log(keyArray);
    // ["ID","name","IP","active"]
    now 
    foreach(var item as keyArray)
    {
    sql = "IF COL_LENGTH('TABLENAME', item) IS NULL alter table [TABLENAME] add [item] int default 0 NOT NULL"
    //run this sql query using sql command and see the magic
    }
