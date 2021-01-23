    public abstract class BaseObject {}
    public class Object1 : BaseObject {}
    public class Object2 : BaseObject {}
    
    public interface IPlugin
    {
        void Process();
    }
    
    public class BasePlugin<T> : IPlugin where T : BaseObject
    {
        protected MyManager _manager;        
    
        protected List<T> _list;
        public BasePlugin(MyManager manager, List<T> list)
        {
            this._manager = manager;            
            this._list = list;
        }
    
        public virtual void Process() { }
    }
    
    public class Plugin1 : BasePlugin<Object1>
    {    
        public Plugin1(MyManager manager, List<Object1> list)
            : base(manager, list) { }
    
        public override void Process() 
        {
            base.Process();
        }
    }
    
    public class Plugin2 : BasePlugin<Object2>
    {
        public Plugin2(MyManager manager, List<Object2> list)
            : base(manager, list) { }
    
        public override void Process() 
        {
            base.Process();
        }
    }
