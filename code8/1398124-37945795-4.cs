        private Pony(SerializationInfo info, StreamingContext context) {
    
          foreach (SerializationEntry entry in info) {
            switch (entry.Name) {
              case "Id":
                this.Id = (int)entry.Value;
                break;
              case "Name":
                this.Name = (string)entry.Value;
                break;
              case "BFF":
                this.BFF = (Pony)entry.Value;
                break;
            }
          }
        }
    
        public void GetObjectData(SerializationInfo info, StreamingContext ontext) {
          info.AddValue("Id", Id);
          info.AddValue("Name", Name);
          info.AddValue("BFF", BFF);
        }
      }
