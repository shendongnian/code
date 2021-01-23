    Random rnd1 = new Random(Environment.TickCount);
    Image[] Images = new Image[6];
    int[] CurrentStatus = new int [3];
    Images[0] = Image.FromFile("FileNameFornumber1");
    Images[1] = Image.FromFile("FileNameFornumber2");
    Images[2] = Image.FromFile("FileNameFornumber3");
    Images[3] = Image.FromFile("FileNameFornumber4");
    Images[4] = Image.FromFile("FileNameFornumber5");
    Images[5] = Image.FromFile("FileNameFornumber6");
    
    //change numbers every tick
    private Timer_TickHandler(object sender, EventArgs e)
    {
       this.CurrentState[0] = rnd1.Next(1, 6);
       this.CurrentState[1] = rnd1.Next(1, 6);
       this.CurrentState[2] = rnd1.Next(1, 6);
       this.PictureBox1.Image = Images[this.CurrentStatus[0]-1];
       this.PictureBox2.Image = Images[this.CurrentStatus[1]-1];
       this.PictureBox3.Image = Images[this.CurrentStatus[2]-1];
    }
