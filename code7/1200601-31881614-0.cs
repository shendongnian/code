    string[] strArr = customersBOX.Text.Split(',');
    foreach (string item in strArr)
    {
        item.Trim();
        System.IO.Directory.CreateDirectory(foldercreationPATH.Text + "\\Tosystem\\" + item);            
    }
