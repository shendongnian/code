    protected void Button1_Click(object sender, EventArgs e)
    {
          HttpWebRequest myWebRequest = null;
          HttpWebResponse myWebResponse = null;
          try
          {
              string sURL = "sample/api.aspx";
              sURL = sURL + "?apiusername=" + HttpUtility.UrlEncode("123");
              sURL = sURL + "&apipassword=" + HttpUtility.UrlEncode("xyz");
              sURL = sURL + "&mobileno=" + HttpUtility.UrlEncode("6141234567");
              sURL = sURL + "&senderid=" + HttpUtility.UrlEncode("try");
              sURL = sURL + "&languagetype=" + "1";
              sURL = sURL + "&message=" + HttpUtility.UrlEncode("testing sms from api");
              myWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(sURL);
              myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
              if (myWebResponse.StatusCode == HttpStatusCode.OK)
              {
                  Stream oStream = myWebResponse.GetResponseStream();
                  StreamReader oReader = new StreamReader(oStream);
                  string sResult = oReader.ReadToEnd();
                  if (long.Parse(sResult) > 0)
                  {
                      Response.Write("success - MT ID :" + sResult);
                  }
                  else
                  {
                      Response.Write("fail - Error code :" + sResult);
                  }
              }
          }
          catch (Exception ex)
          {
                Response.Write("Some issue happen");
          }
          finally
          {
              if ((myWebResponse != null))
              {
                    myWebResponse.Close();
              }
          }
     }
