        string imagepath = ProfilePicURL.Text;    
        var imageFile = new System.IO.FileInfo(imagepath);
        if (imageFile.Exists)// check image file exist
        {
            // get your application folder
            var applicationPath=System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        
            // get your 'Uploaded' folder
            var dir=new System.IO.DirectoryInfo(System.IO.Path.Combine(applicationPath,"uploaded"));
            if(!dir.Exists)
                dir.Create();
            // Copy file to your folder
            imageFile.CopyTo(System.IO.Path.Combine(dir.FullName,string.Format("{0}_{1}",
                FirstName.Text.Replace(" ", String.Empty),
                LastName.Text.Replace(" ", String.Empty))));
        }
