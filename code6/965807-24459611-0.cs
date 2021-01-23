    class TicketManager : DataManager<Ticket>
    {
        public TicketResponse GetResponseById(String id)
        {
            return this.Context.Set<TicketResponse>().Find(id);
        }
    }
