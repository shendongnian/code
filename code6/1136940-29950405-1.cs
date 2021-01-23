    [DataContract]
    class Player
    {
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public int Tee { get; set; }
        [DataMember]
        public int Team { get; set; }
        [DataMember]
        public int Flight { get; set; }
        [DataMember]
        public int Ohc { get; set; }
        [DataMember]
        public decimal HcIx { get; set; }
    }
