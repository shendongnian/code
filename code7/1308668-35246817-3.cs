        public class IdEventArgs : EventArgs
        {
            public Guid Id { get; set; }
        
        }
        public class ReadEventArgs : IdEventArgs
        {
        
            
            public byte[] Data{ get; set; }
        
        }
