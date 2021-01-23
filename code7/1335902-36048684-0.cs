    private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if(e.KeyCode == Keys.Enter || e.KeyValue == (char)Keys.Return)
                //if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
                {
                    var items = new[] { 500 + "objects here" };
                    if (toolStripTextBox1.Text.StartsWith("www."))
                    {
                        webBrowser1.Navigate(toolStripTextBox1.Text);
                    }
                    if (toolStripTextBox1.Text.StartsWith("http://"))
                    {
                        webBrowser1.Navigate(toolStripTextBox1.Text);
                    }
                    if (toolStripTextBox1.Text.StartsWith("https://"))
                    {
                        webBrowser1.Navigate(toolStripTextBox1.Text);
                    }
                    if (items.Any(item => toolStripTextBox1.Text.Contains(item)))
                    {
                        webBrowser1.Navigate(toolStripTextBox1.Text);
                    }
                    else
                    {
                        webBrowser1.Navigate("https://www.google.ca/?gws_rd=ssl#safe=active&q=" + toolStripTextBox1);
                    }
                }
