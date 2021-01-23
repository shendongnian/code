    public class GetFileResult
    {
        public GetFileResult(GetFileResultState state, string filename, byte[] bytes)
        {
            State = state;
            Filename = filename;
            Bytes = bytes;
            ErrorMessage = null;
        }
        public GetFileResult(string errorMessage)
        {
            State = GetFileResultState.Error;
            Filename = null;
            Bytes = null;
            ErrorMessage = errorMessage;
        }
        
        public GetFileResultState State { get; }
        public string Filename { get; }
        public byte[] Bytes { get; }
        public string ErrorMessage { get; }
    }
    
    public enum GetFileResultState
    {
        Success, Error
    }
