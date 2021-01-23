    public void Initialize()
    {
        Directory.GetFiles(@"C:\Users\Syeda\Desktop\Photos");
        List<string> pictureList = new List<string>(Directory.GetFiles(@"C:\Users\Syeda\Desktop\Photos"));
    }
