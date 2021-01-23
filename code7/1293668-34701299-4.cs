    public class Animation : IAnimation
    {
        public event Action OnEnd;
        public void CallEnd()
        {
            OnEnd();
        }
    }
