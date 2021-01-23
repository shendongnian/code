    public class MyDirectory
        {
            public MyDirectory()
            {
                MyDirectories = new List<MyDirectory>();
            }
            public string Path { get; set; }
            public List<MyDirectory> MyDirectories { get; set; }
        }
  
