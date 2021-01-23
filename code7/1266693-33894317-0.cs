    namespace WorkOrder.Service
    {
        [DataContract]
        public class TicketDetail : WorkOrder.Service.Ticket
        {
            public TicketDetail(Ticket ticket)
            {
                 this.StatusId = ticket.StatusId;
            }
            [DataMember]
            public List<WorkLogView> WorkLogs { get; set; }
        }
    }
