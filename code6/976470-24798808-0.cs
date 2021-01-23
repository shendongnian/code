      public Guid MesageUniqueId
        {
            get { return messageUId; }
            set {
                 if (messageUId  == Guid.Empty) 
                    messageUId = value; 
            } 
        }
