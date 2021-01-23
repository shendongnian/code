    private void MainScreenThread() {
       ReadData();
       initial = bufferToJpeg(); //full screen first shot.
       pictureBox1.Image = initial;
       while (true) {
        int pos = ReadData();
        int x = BlockX();
        int y = BlockY();
        Bitmap block = bufferToJpeg(); //retrieveing the new block.
        using(Graphics g = Graphics.FromImage(initial)) {
           g.DrawImage(block, x, y); //drawing the new block over the inital image.
           this.Invoke(new Action(() => pictureBox1.Refresh())); //refreshing the picturebox-will update the intial;
       }
     }
    }
