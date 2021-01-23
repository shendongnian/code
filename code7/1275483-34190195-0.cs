    /// <summary>
    /// original DTO, is fixed
    /// </summary>
    [DataContract]
    class DTO
    {
        [DataMember]
        public DateTime FirstDate { get; set; }
            
    }
    
    /// <summary>
    /// Our own DTO, will act as surrogate
    /// </summary>
    [DataContract(Name="DTO")]
    class DTO_UTC
    {
        [DataMember]
        public string FirstDate { get; set; }
    }
