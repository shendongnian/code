    public class Task
    {
        ...
        public String ToDelimitedString()
        {
            return String.Format("{0}#{1}", TaskId, IsComplete);
        }
    }
