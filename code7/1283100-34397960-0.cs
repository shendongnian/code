    public TrafficLight : IObserver {
       ...
      public void Notify() {
         if(timePassed > sachedulledTime) {
            SwithcLight();
         }
      }
