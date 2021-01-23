    interface IMask : IList<System.Drawing.Point>
    {
        public void MoveTo(System.Drawing.Point newCenter);
        // ...
        public void 
    }
    public class Mask : IMask
    {
        // ...
    }
    public class Spot
    {
        public Mask Mask = new Mask();
        // ...
    }
    public  class Marker
    {
        public Mask Mask = new Mask();
        /// ...
    }
