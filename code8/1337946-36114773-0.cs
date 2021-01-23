    public interface IRandomMazeGenerator<TMaze,T> where TMaze: IMaze<T>, new(){
        TMaze Generate();
    }
    
    public class EmptyMazeGenerator<TMaze,T> : IMazeGenerator<TMaze,T> where T: IMaze<T>,new(){
        public EmptyMazeGenerator(){}
        public TMaze Generate(){
            return new TMaze();
        }
    }
