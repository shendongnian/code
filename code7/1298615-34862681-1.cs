    public void btnDelete(object sender, EventArgs e)
    { 
        var exists = false;
        if(File.Exists("C:\\\test.txt")) 
        {
            exists = true;
        } 
    
        if(exists)
        {
            File.Delete("C:\\\test.txt");
        }
    }
