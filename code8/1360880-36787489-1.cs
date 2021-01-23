    public class Ford : Car
    {
         public Engine engine;
         // car is composed of multiple parts, including the engine
         public Ford()
         { 
              this.engine = new FordEngine();
         }
