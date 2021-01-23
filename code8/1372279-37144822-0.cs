    string timeProcessed = DateTime.Now.ToString();
    byte[] bytefiles = attachment.ContentBytes;
    string cleanName = MakeCleanName(userEmail.Subject, attachment.Name);       
    // updated this in order to prevent images with the same name from overwritting eachother.
    if (File.Exists(path))
    {                                  
        cleanName = Path.GetFileNameWithoutExtension(attachment.Name).ToString()+"(" + counter + ")" + "-(Recieved - " + timeProcessed.Replace(":",".").Replace("/",".") + " )"+ Path.GetExtension(attachment.Name); << this value is not updated in the path variable.
    
    }
    string path = employeeStarPath + "\\" + cleanName;
