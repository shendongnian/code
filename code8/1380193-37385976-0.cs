    Dictionary<int, WebBrowser> browsers = new Dictionary<int, WebBrowser>();
    Button1_Click(object sender, EventArgs e){
         TabPage newtab = new TabPage();
         WebBrowser newbrowser = new WebBrowser();
         newtab.Controls.Add(newbrowser);
         newbrowser.Navigate("google.com");
         tabControl1.TabPages.Add(newtab);
         browsers.Add(tabControl1.TabCount-1, newbrowser);
    }
    Button2_Click(object sender, EventArgs e){
         browsers[tabControl1.SelectedIndex].Navigate(Text1.Text);
    }
