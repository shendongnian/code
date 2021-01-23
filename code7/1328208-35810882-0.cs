    public void MethodUsingTonsOfMemory(){
      // do memory intensive stuff
      GC.Collect();
      GC.WaitForPendingFinalizers(); // wait for memory to be released
      Debug.WriteLine("Memory should be clear now");
    }
