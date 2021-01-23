    public interface IApple { }
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IApple))]
    public class Apple : IApple 
    { 
        private static int appleCounter = 0;
        private int id;
        public Apple() 
        {
            this.id = ++appleCounter;
        }
        public override string ToString()
        {
            return "Apple #" + this.id.ToString();
        }
    }
