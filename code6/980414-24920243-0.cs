    public List<SomeObject > CheckUsableID(int id, List<SomeObject > list) 
    {
          var listUsableId = new List<SomeObject >();
          foreach(var object in list)
            {
                if (object.Id == id)
                {
                    listUsableID.add(object);
                }
            }
           return listUsableId;
    
    }
    public class SomeObject 
    {
        public int Id { get; set }
    }
