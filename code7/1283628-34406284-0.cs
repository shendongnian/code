        private void button1_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> datas = new List<Dictionary<string, string>>();
            Dictionary<string,string> d1 = new Dictionary<string,string> ();
            d1.Add ( "key11","value11");
            d1.Add ( "key12","value12");
            Dictionary<string,string> d2 = new Dictionary<string,string> ();
            d2.Add ( "key21","value21");
            d2.Add ( "key22","value22");
            datas.Add(d1);
            datas.Add(d2);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string serialized = serializer.Serialize (datas);
            List<Dictionary<string, string>> deserialized = serializer.Deserialize<List<Dictionary<string, string>>>(serialized);
        }
