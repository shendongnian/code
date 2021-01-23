      class Live {
        // Please, note => instead of =
        Thread scheduler => new Thread(UpdateResults);
    
        public Live() {
          scheduler.Start();
        }
    
        public void UpdateResults() {
          //do some stuff
        }
      }
