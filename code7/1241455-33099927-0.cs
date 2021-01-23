    public interface IPlugin<T> where T: BaseObject 
    {
        void Process();
    }
    public class BasePlugin<T> : IPlugin<T>
    {
        protected MyManager _manager;        
        protected List<T> _list;
        public BasePlugin(MyManager manager, List<T> list)
        {
            this._manager = manager;    
           _list = list;        
        }
    
        public virtual void Process() {... }
    }
    
