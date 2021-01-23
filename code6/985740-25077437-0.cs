    private FileStream _myFileStream;
    private void LoadContent()
    {
       _myFileStream = File.Open("myLevelDataThatIKeepOpen.lvl", FileMode.Append);
    }
    
    private void UnloadContent()
    {
       if (_myFileStream != null)
       {
         _myFileStream.Close();
         _myFileStream.Dispose();
       }
    }
