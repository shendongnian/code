     private void button1_Click(object sender, EventArgs e)
     {
         Uri link = new Uri("http://www.mywebsite.com");
         webControl1.Source = link;
         string Values="";
         WebSession session = WebCore.CreateWebSession("d:\\temp", WebPreferences.Default);
         session.SetCookie(link, Values, true, **false**);
    }
