    public class ChronosItem 
    {
        [Column, Key, Required, MaxLength(26), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get;  set; }
        ....
