    private void bWorker1_DoWork(object sender, DoWorkEventArgs e)  
    {  
        var frame1;
        var frame2;
        if (pictureBox2.InvokeRequired) { pictureBox2.Invoke((MethodInvoker)delegate { frame1 = pictureBox2.BackgroundImage; }); } else { frame1 = pictureBox2.BackgroundImage; }
        if (pictureBox3.InvokeRequired) { pictureBox3.Invoke((MethodInvoker)delegate { frame2 = pictureBox3.BackgroundImage; }); } else { frame2 = pictureBox3.BackgroundImage; }
        
        while (true)
        {
            if (pictureBox1.InvokeRequired) { pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.BackgroundImage = frame1; }); } else { pictureBox1.BackgroundImage = frame1; }
            if (pictureBox1.InvokeRequired) { pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.BackgroundImage = frame2; }); } else { pictureBox1.BackgroundImage = frame2; }
        }
    }
