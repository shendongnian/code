    private Guid? messageUId;
     public Guid MesageUniqueId
        {
            get { return messageUId; }
            set {   
                  if (null == messageUId ) 
                  { 
                       messageUId = value;              
                  }
                  else  
                  { 
                      throw new InvalidOperationException("Message id can be assigned only once");
                  }
         }
        }
