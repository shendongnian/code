    class Baseclass
    {
        public virtual void callingbasefuntion()
        {
            throw new caughtexecption();
        }  
    }
    
    class Derivedclass : Baseclass
    {
        public override void Initialize()
        {
            try
            {
                base.callingbasefuntion();
            }
            catch (caughtexecption)
            {
                ...
            }
        }
    }
    var object = new Derivedclass ();
    object.callingbasefuntion();
