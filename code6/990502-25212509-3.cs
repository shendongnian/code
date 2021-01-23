    public abstract class Module<T> where T : BasicData {
        protected T value;
        public abstract void Update();
        public virtual T Value {
            get;
            set;
        }
    }
    public class Handler
    {
        LinkedList<Modul<BasicData>> modulCollection = new LinkedList<Data<BasicData>>();
    
        pulic void Add(Modul<BasicData> m)
        {
            this.modulCollection.add(m);
        }
    
        public void Update() {
            foreach (Modul<BasicData> d in this.modulCollection)
                  d.update();
        }
    }
