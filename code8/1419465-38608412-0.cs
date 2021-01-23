    public abstract class Scalable<T>
    {
        protected double x, y, z;
    
        public T Scale(double sc)
        {
            this.x = sc * x; this.y = sc * y; this.z = sc * z;
            return this;
        }
    
        public Scalable(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
    }
