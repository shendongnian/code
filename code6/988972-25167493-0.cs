    class SomeClass
    {
        FileStream FILEREADER = null;
        
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
        }
    }
