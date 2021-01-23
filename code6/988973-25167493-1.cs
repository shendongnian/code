    class SomeClass
    {
        void SomeMethod()
        {
            using (FileStream FILEREADER = new FileStream(
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
            using (FileStream FILEREADER = new FileStream(
                "text_file.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                // do stuff
            }
        }
    }
