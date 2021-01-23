    public abstract class Agent : ISupportInitialize
    {
        private bool _initialized = false;
        private IPhysics _pluginPhysics;
        protected IPhysics PluginPhysics 
        { 
            get
            {
                if(!_initialized)
                    EndInit();
                return _pluginPhysics;
            }
        }
    
        protected Agent(...)
        {
        }
    
        protected abstract IPhysics CreatePhysics();
        ISupportInitialize.BeginInit()
        {
           //We make this a explicit implementation because it will not
           //do anything so we don't need to expose it.
        }
        public void EndInit()
        {
            if(_initialized)
                return;
            _initialized = true;
            _pluginPhysics = CreatePhysics();
        }
    }
    
    public class Bicycle : Agent
    {
        private double maxA;
        Object _anotherParameter;
        public Bicycle(Object anotherParameter)
        {
            _anotherParameter = anotherParameter;
        }
        protected override IPhysics CreatePhysics()
        {
            ComputationOfMaxA();
            return new Physics(anotherParameter, maxA);
        }
    }
