    public abstract class AbstractState
    {
    }
    public abstract class AbstractState<T> : AbstractState
        where T : StatefulObject
    {
        protected T statefulObject;
        public AbstractState(T statefulObject) {
            this.statefulObject = statefulObject;
        }
    }
    public abstract class StatefulObject : MonoBehaviour
    {
        public AbstractState State { get; set; }
    }
