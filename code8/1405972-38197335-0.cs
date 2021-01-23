    namespace Company.Hololens
    {
        public enum GazeState
        {
            None = -1, NoHit, Hit
        }
        public class CursorEventArg : EventArgs
    	{
    
    	}
    	public class CursorController : Singleton<CursorController>
        {
        }
    }
