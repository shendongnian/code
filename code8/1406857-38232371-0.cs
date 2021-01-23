    private void MainScreenThread() {
    
      ReadData();
      initial = bufferToJpeg(); 
      pictureBox1.Image = initial;
      Graphics g = Graphics.FromImage(initial);
    
      while (true) {
        int pos = ReadData();
        int x = BlockX();
        int y = BlockY();
        Bitmap block = bufferToJpeg(); 
     
        g.DrawImage(block, x, y); 
        this.Invoke(new Action(() => pictureBox1.Refresh())); 
    
      }
    }
