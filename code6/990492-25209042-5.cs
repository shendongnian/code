    public class Handler
    {
        LinkedList<IUpdateable> modulCollection = new LinkedList<IUpdateable>();
    
        void add<T>(Modul<T> m) // It is generic now
        {
            this.dataCollection.add(m);
        }
    
        void update(){
            for(IUpdateable d : this.modulCollection){
                  d.update();
            }
        }
    }
