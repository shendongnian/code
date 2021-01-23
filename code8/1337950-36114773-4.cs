    public interface IRandomMazeGenerator<TMaze,T> where TMaze: IMaze<T>, new(){
        TMaze Generate();
    }
    public class MatrixMaze : IMaze<Point2D>{public MatrixMaze(){..}}
    public class EmptyMazeGenerator<TMaze,T> : IMazeGenerator<TMaze,T> where T: IMaze<T>,new(){
        public TMaze Generate(){
            return new TMaze();
        }
    }
