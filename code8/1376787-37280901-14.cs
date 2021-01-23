    public void F_Thread()
    {
        for (int i = 0; i < Convert.ToInt16(textBox1.Text); i++)
        {
            if (pictureBox1.InvokeRequired ) 
                this.Invoke(new UpdatePBInvoker(UpdatePB), -10);
                
            Thread.Sleep(100);
        }
    }
    delegate void UpdatePBInvoker(int moveX);
    private void UpdatePB(int moveX)
    {
        pictureBox1.Left = pictureBox1.Left + moveX;
    }
