    public interface IBase<T>
        {
            void OnSpecialEvent(T e);
        }
    
        public class Alpha : IBase<AlphaArgs>
        {
            public void OnSpecialEvent(AlphaArgs e)
            {
                throw new NotImplementedException();
            }
        }
    
        public class Beta : IBase<BetaArgs>
        {
            public void OnSpecialEvent(BetaArgs e)
            {
                throw new NotImplementedException();
            }
        }
    
        public class AlphaArgs
        {
            public int A { get; }
            public object B { get; }
        }
    
        public class BetaArgs
        {
            public string C { get; }
        }
