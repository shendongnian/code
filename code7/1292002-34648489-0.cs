    public static List<MadjType> MAASource { get; private set; }
    static MyClass()
    {
        switch (ConfigurationResource.Version)
        {
            case "Version1":
                MAASource = new List<MadjType>
                    {
                        new MadjType { Id = 1, Name = "MAA - 1" },
                        new MadjType { Id = 2, Name = "MAA - 2" },
                        new MadjType { Id = 3, Name = "MAA - 3" },
                        new MadjType { Id = 4, Name = "MAA - 4" },
                        new MadjType { Id = 5, Name = "MAA - 5" },
                        new MadjType { Id = 6, Name = "MAA - 6" },
                        new MadjType { Id = 7, Name = "MAA - 7" },
                        new MadjType { Id = 8, Name = "MAA - 8" },
                        new MadjType { Id = 9, Name = "MAA - 9" },
                        new MadjType { Id = 10, Name = "MAA - 10" },
                    };
                break;
            case "Version2":
                MAASource = new List<MadjType>
                    {
                        new MadjType { Id = 1, Name = "MAA - 1" },
                        new MadjType { Id = 2, Name = "MAA - 2" },
                        new MadjType { Id = 3, Name = "MAA - 3" },
                        new MadjType { Id = 4, Name = "MAA - 4" },
                        new MadjType { Id = 5, Name = "MAA - 5" },
                        new MadjType { Id = 6, Name = "MAA - 6" },
                        new MadjType { Id = 7, Name = "MAA - 7" },
                    };
                break;
        }
    }
