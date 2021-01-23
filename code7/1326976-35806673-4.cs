    public interface ICanSetStatus
    {
        void SetStatus(FileStatus fileStatus);
        // maybe add a second parameter with information about the file, so that an 
        // implementation of this interface knows everything that's needed
    }
    public class StatusSetter : ICanSetStatus
    {
        public void SetStatus(FileStatus fileStatus)
        {
            // do whatever's necessary...
        }
    }
