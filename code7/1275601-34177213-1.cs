    public partial class ChannelFee
    {
            [ForeignKey("SubSource_id")]  
            public virtual SubSource SubSource { get; set; }        
            public int SubSource_id { get; set; }     
           
    }
