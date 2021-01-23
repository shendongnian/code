    namespace Logistic.Models
    {
        public class Dispatch
        {
            public int DispatchId { get; set; }
            public int CustomerId { get; set; }
            public int RecipientId { get; set; }
            
            [ForeignKey("CustomerId")]
            public Client Customer { get; set; }
            [ForeignKey("RecipientId")]
            public Client Recipient { get; set; }
        }
    }
