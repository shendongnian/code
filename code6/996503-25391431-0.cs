    public class AsmbLine 
    {
        public int linenumber { get; set; }
        public Ticket[] ticketlist { get; set; }
        public string[] platesizes { get; set; }
        public string[] platetypes { get; set; }
        public string[] platecounts { get; set; }
        //public int[] cellidsallowed { get; set; } //uncomment these two lines to fix
        private int[,] cellidsallowed;  
        public int[,] Cellidsallowed         
        {   get { return cellidsallowed; } 
            set { cellidsallowed = value; }         
        }
    }
