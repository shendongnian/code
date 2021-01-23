    public class Bar<T> : IBar {
        public void Boom() {
            Console.WriteLine("I am booming");
        }
    }
    
    interface IBar {
        void Boom();
    }
    ...
    var genericBar = (IBar)Activator.CreateInstance(specificRepoType);
