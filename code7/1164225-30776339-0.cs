    public class SearchedInstruction
    {
        private int _idWorkCenter = -1;
        public string IdWorkCenter
        {
            get { return _idWorkCenter != -1 ? _idWorkCenter : string.Empty; }
            set { _idWorkCenter = value; }
        }
    }
