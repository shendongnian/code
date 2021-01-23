    public class EMG
    {
      // Local variable
      EMG emg = new EMG();
      
      // Task to hod init process
      Task cameraInitTasks;
      public EMG():base()
      {
        InitMyOtherStuff(); // Other init code
		
        // Create your task on class initialization
        cameraInitTasks = new Task(EMG.startemg);
        // Start it
		cameraInitTasks.Start();
				
      }
	  public button2_Click()
	  {
         // jic, wait until task finished
		 cameraInitTasks.Wait();
         // This one should take little time, right?
         emg.Start();
         // Go and take the picture
         DoPictureTake()
	  }
	  ...
	}
