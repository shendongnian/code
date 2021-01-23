    private Pony(SerializationInfo info, StreamingContext context) {
    
          foreach (SerializationEntry entry in info) {
            switch (entry.Name) {
              case "Id":
                this.Id = (int)entry.Value;
                break;
              case "Name":
                this.Name = (string)entry.Value;
                break;
              case "BFF.Id":
                var bffId = (int)entry.Value;
                this.BFF = GetPonyById(bffId); // You have to implement this
                break;
            }
          }
        }
    
        public void GetObjectData(SerializationInfo info, StreamingContext ontext) {
          info.AddValue("Id", Id);
          info.AddValue("Name", Name);
          info.AddValue("BFF.Id", BFF.Id);
        }
...
