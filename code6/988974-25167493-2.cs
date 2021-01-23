    class SomeClass
    {
        FileStream FILEREADER; // will be null by default
        
        void SomeMethod()
        {
            using (FILEREADER = new FileStream(
                "text_file.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                // do stuff
            }
            FILEREADER = null;
        }
        void SomeMethod2()
        {
            using (FILEREADER = new FileStream(
                "text_file.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                // do stuff
            }
            FILEREADER = null;
        }
    }
