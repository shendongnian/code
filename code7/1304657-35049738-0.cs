    public class Ticket
    {
       public int TicketID { get; set; }
       private string title;
       public string Title
       {
            get { return title; }
            set
            {                
                title = value;
                UpdateDate = DateTime.Now;
            }
        }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }   
    }
