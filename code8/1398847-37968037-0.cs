    System.ComponentModel.IContainer components= new System.ComponentModel.Container();
    Multimedia.Timer mmTimer=new Multimedia.Timer(this.components);
    mmTimer.Mode = Multimedia.TimerMode.OneShot;
    mmTimer.Period = 40;
    mmTimer.Resolution = 1;
    mmTimer.SynchronizingObject = this;
    mmTimer.Tick += new System.EventHandler(this.mmTimer_Tick);
    private void mmTimer_Tick(object sender, System.EventArgs e)
    {
       Console.WriteLine("tick after 40 ms");
    }
