    protected void btnSave_Click(object sender, EventArgs e)
    {
         //get the file path
         string filePath = Session["FileDirectory"].ToString();
         SaveFiles(filePath);
    }
    public void SaveFiles(string fileDirectory)
    {
        //copy the file from temp serevr to the permanent folder
        File.Copy(fileDirectory, "your new path", false);
        //deletes the file from temp server
        Directory.Delete(fileDirectory, true);
    }
    
