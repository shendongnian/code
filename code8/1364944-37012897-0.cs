    public abstract class Element
    {
        protected virtual void copyFrom(Element other)
        {  
        }
    
        protected abstract Elememt newInstanceOfMyType();
        public object clone()
        {
            var instance= newInstanceOfMyType();
            instance.copyFrom(this);
            return instance;        
        }
    }
