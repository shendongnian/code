        for (int i = 0; i < 5; i++)
        {
            if (ct.IsCancellationRequested)
            {
                return; 
            }
            if (richTextBox2.InvokeRequired)
            {
                richTextBox2.Invoke((MethodInvoker)delegate
                {
                    richTextBox2.AppendText("I AM IN: " + Thread.CurrentThread.Name + "\n");
                });
    
                Thread.Sleep(1400);
            }
        }
    }
