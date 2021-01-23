    private void button2_Click(object sender, EventArgs e)
    {
        HtmlDocument doc = webBrowser1.Document;
        HtmlElement HTMLControl2 = doc.GetElementById("flightno-filter");
        //HTMLControl.Style = "'display: none;'";
        if (HTMLControl2 != null)
        {
            // HTMLControl2.Style = "display: none";
            HTMLControl2.InnerText = textBox1.Text;
            HTMLControl2.Focus();              // Set focus to input box
            SendKeys.SendWait("{Right}");      // Send "Right" key
            textBox1.Focus();                  // Give focus back for one of WinForms control
        }
    }
