    [Serializable]
      public class Pony  {
        public int Id {
          get; set;
        }
        public string Name {
          get; set;
        }
        public Pony BFF {
          get; set;
        }
    
        public Pony() {
        }
       
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) {
          Console.WriteLine(this.Id + " " + this.Name + " " + this.BFF?.Name);
        }
      }
