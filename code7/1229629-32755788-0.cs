    /* View model */
    public partial class ClientRegModel
    {
        public int serial { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password")]
        public string ComparePass { get; set; }
    }
    /* Your DbContext or data class */
    public partial class ClientReg
    {
        public int serial { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
