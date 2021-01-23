    protected void Button1_Click(object sender, EventArgs e)
    {
        string input = TextBox1.Text;
        string sURL;
        sURL = "http://api.urlvoid.com/api1000/key/host/" + input + "/";
        HttpWebRequest wrGETURL = (HttpWebRequest)WebRequest.Create(sURL);
        using (Stream stm = wrGETURL.GetRequestStream())
        {
            using (StreamWriter stmw = new StreamWriter(stm))
            {
                stmw.Write(input);
            }
        }
        using (StreamReader responseReader = new StreamReader(wrGETURL.GetResponse().GetResponseStream()))
        {
            string resultString = responseReader.ReadToEnd();
            if (File.Exists(@"C:\Users\user\Desktop\API_Call_Test.txt"))
                File.Delete(@"C:\Users\user\Desktop\API_Call_Test.txt");
            File.Create(@"C:\Users\user\Desktop\API_Call_Test.txt").Close();
            File.WriteAllText(@"C:\Users\user\Desktop\API_Call_Test.txt", resultString);
        }
    }
