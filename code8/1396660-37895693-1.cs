    public sealed class Page
    {
       ....
        [InverseProperty("PageOfThisKey")]
        public virtual ICollection<Keys> KeysOfThisPage { get; set; }
       ...
    }
    public sealed class Key
    {
       ...
        public Int32 PageID { get; set; }
        [ForeignKey("PageID")]
        [InverseProperty("KeysOfThisPage")]
        public virtual Page PageOfThisKey { get; set; }
       ...
    }
