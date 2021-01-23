    using (Process ExternalProcess = new Process())
    {
       ExternalProcess.StartInfo.FileName = @"C:\users\bnickerson\desktop\script\RegScript.cmd";
       ExternalProcess.Start();
       ExternalProcess.WaitForExit();
    }
    
    string imgLoc = @"C:\users\bnickerson\Desktop\script\result\last.png";
    if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); }
    using (Image myImage = Image.FromFile(imgLoc))
    {
       pictureBox1.Image = (Image)myImage.Clone();
       pictureBox1.Update();
    }
