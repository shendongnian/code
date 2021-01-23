     private  void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("https://it.images.search.yahoo.com/images");
        }
        int a = 1;
        private async void button1_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                webBrowser1.Document.GetElementById("yschsp").InnerText = textBox1.Text;
                webBrowser1.Document.GetElementsByTagName("input")[1].InvokeMember("click");
                do
                {
                    Application.DoEvents();
                } while (webBrowser1.ReadyState != WebBrowserReadyState.Complete);
                await PutTaskDelay();
                pictureBox1.ImageLocation = webBrowser1.Document.GetElementsByTagName("img")[0].GetAttribute("src");
                a = a + 1;
            }
            else
            {
                webBrowser1.Document.GetElementById("yschsp").InnerText = textBox1.Text;
               
                webBrowser1.Document.GetElementById("sbx_x").InvokeMember("click");
                do
                {
                    Application.DoEvents();
                } while (webBrowser1.ReadyState != WebBrowserReadyState.Complete);
                await PutTaskDelay();
                pictureBox1.ImageLocation = webBrowser1.Document.GetElementsByTagName("img")[0].GetAttribute("src");
            }
        }
        async Task PutTaskDelay()
        {
            await Task.Delay(1000);
        }
