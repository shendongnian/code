    private void ml_MouseDownExt( object sender,MouseEventExtArgs  e)
    {
          e.Handled= true;
          var wrongThread = new Action(()=>
          {
              // I have got hard disk serial number here
              string sn = HardDisk.Serial;
              //put anything else you were planning on doing with sn here
          }
          BeginInvoke(wrongThread, null);
    }
