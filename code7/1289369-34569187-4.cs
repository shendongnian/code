    Process task1 = null;
    task1 = new Process();
    private void main()
    {
         task1.StartInfo.FileName = something.bat;
         ............
    }
    private void Update()
    {
       task1.Start();
       task1.WaitForExit();
    }
