    class User
    {
        public string username { get; set; }
        public ICollection<Connection> Connections { get; set; }
    }
    
    class Connection
    {
        public string ConnectionId { get; set; }
        public string RoomName { get; set; }
    }
