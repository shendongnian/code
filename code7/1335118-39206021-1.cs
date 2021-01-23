        public override void Up()
        {
            Convert(true,"DownloadToken");
        }
        public override void Down()
        {
            Convert(false, "DownloadToken");
        }
