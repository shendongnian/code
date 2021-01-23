    Button2_Click(object sender, EventArgs e)
    {
        foreach (Control item in page.Controls)
        {
            if (item is WebBrowser)
            {
                ((WebBrowser)item).Navigate(Text1.Text);
                break;
            }
        }
    }
