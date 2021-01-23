    using(FileStream fs = System.IO.File.Open(sPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
    {
        using(System.IO.StreamReader filesr = new System.IO.StreamReader(fs))
        {
            //read from streamreader
        }
    }
