        [ForeignKey("TileImageID")]
        public Image TileImage { get; set; }
        [Column("TileImageID")]
        public int? TileImageID { get; set; }
        [ForeignKey("CoverImageID")]
        public Image CoverImage { get; set; }
        [Column("CoverImageID")]
        public int? CoverImageID { get; set; }
