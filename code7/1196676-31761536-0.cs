        string strNo = TextBox1.Text;
        try
        {
            string sURL = "http://gateway.onewaysms.sg:10002/api.aspx";
            sURL = sURL + "?apiusername=" + HttpUtility.UrlEncode("API3YS3NVIWNP");
            sURL = sURL + "&apipassword=" + HttpUtility.UrlEncode("API3YS3NVIWNPGNZIV");
            sURL = sURL + "&mobileno=" + HttpUtility.UrlEncode(strNo);
            sURL = sURL + "&senderid=" + HttpUtility.UrlEncode("onewaysms");
            sURL = sURL + "&languagetype=" + "1";
            sURL = sURL + "&message=" + HttpUtility.UrlEncode("testing");
            
            HttpWebRequest myWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(sURL);
            HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            .......
        }
