      [System.ComponentModel.Composition.Export(typeof(Interface.IPlugin))]
      public class Plugin : Interface.IPlugin
      {
        private Random random;
        public Plugin()
        {
          this.random = new Random(DateTime.Now.Ticks.GetHashCode());
        }
    
        public string Name
        {
          get { return "Plugin"; }
        }
    
        public double GetRandom()
        {
          return this.random.NextDouble() * 10;
        }
      }
