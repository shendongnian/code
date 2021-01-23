    public class SubDocument {
        //if using objectId as ID
        public ObjectId Id = { get; set;}
        
        public SubDocument(){
            Id = ObjectId.GenerateNewId()
        }
    
    }
