        [NotMapped]
        public long ClientId
        {
            get { return BitConverter.ToInt64(this.ClientIdBytes, 0); }
            set { this.ClientIdBytes = BitConverter.GetBytes(value); }
        }
        [Column("ClientId")]
        public byte[] ClientIdBytes { get; set; }
