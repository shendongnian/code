    class TicketList
    {
        private List<Ticket> _tickets;
        private int _currentPosition;
        public TicketList<IEnumerable<Ticket> tickets>
        {
            _tickets = ticket;
            _currentPosition = 0;
        }
        
        public Ticket GetCurrent()
        {
            return _tickets[_currentPosition];
        }
        public bool CanMoveNext{
            get{
                return _tickets.Any() && _currentTicket != _tickets.Count - 1;
            }
        }
        public Ticket GetNext()
        {
            _currentPosition++;
            return _tickets[_currentPosition];
        }
    }
