        [Column("gps_location")]
        public DbGeometry LocationGeometry { get; set; }
        [NotMapped] // Mapping to DbGeography is not supported by MySQL Connector/Net, see https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework50.html
        public DbGeography Location
        {
            get => LocationGeometry != null ? DbGeography.FromBinary(LocationGeometry.AsBinary()) : null;
            set => LocationGeometry = value != null ? DbGeometry.FromBinary(value.AsBinary()) : null;
        }
