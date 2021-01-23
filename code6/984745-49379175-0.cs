        [Column("gps_location")]
        public DbGeometry LocationGeometry { get; set; }
        [NotMapped] // Mapping to DbGeography is not supported by MySQL Connector/Net, see https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework50.html
        public DbGeography Location
        {
            get => DbGeography.FromBinary(LocationGeometry.AsBinary());
            set => LocationGeometry = DbGeometry.FromBinary(value.AsBinary());
        }
