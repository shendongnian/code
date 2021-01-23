                button1.Visible = false;
                button2.Visible = false;
    
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    this.Invoke((MethodInvoker)delegate { button1.Visible = true; });
    
                    Thread.Sleep(2000);
                    this.Invoke((MethodInvoker)delegate { button2.Visible = true; });
                });
