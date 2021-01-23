    var web = (HttpWebRequest)WebRequest.Create("http://somesite.com/changelog.txt");        
    web.Method = "GET";    
    using (var res = new StreamReader(web.GetResponse().GetResponseStream()))
    {
        string line="";
        while ((line=res.ReadLine())!=null)
        {
            textBox1.AppendText(line+System.Environment.NewLine);
        }
    }
