    public class EMG
    {
      private ManualResetEvent waitHandler = new ManualResetEvent(false);
    
      public void Initialize()
      {
        EMG emg = new EMG();
        emg.Initialize();  //takes a lot of time 
        waitHandler.WaitOne();
        emg.Start();
      }
    
      public void Start()
      {
         waitHandler.Set();
      }
    }
-----
    private void button2_Click(object sender, EventArgs e)
    {   
      Task cameraTask = new Task(Camera.start)
      cameraTask .Start();
      EMG.Start();
    }
