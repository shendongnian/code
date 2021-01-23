    public abstract class BasePoly
    {
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Width { get; set; }
        public abstract double Height { get; set; }
    }
    public abstract class BasePoly<T>
    {
        public T poly { get; public set; }
        protected BasePoly(T poly) { this.poly = poly; }
    }
    public class PolyLineAdapter : BasePoly<PolyLine>
    {
        public class PolyLineAdapter(PolyLine poly) : base(poly) {}
        // override abstracts and forward to inner PolyLine instance at 'this.poly'
    }
    public class FaceAdapter : BasePoly<Face>
    {
        public class FaceAdapter(Face poly) : base(poly) {}
        // override abstracts and forward to inner Face instance at 'this.poly'
    }
    interface IEntity
    {
        void BasePoly GetPoly();
        void void   InsertPoly(BasePoly poly);
    }
    public abstract class Entity<TEntity> where TEntity : BasePoly
    {
        void TEntity GetPoly()
        {
            //calling third party APIs by calling abstract methods to be implemented by specific provider
            return Autocad Polyline object
        }
        void InsertPoly(TEntity poly){...}
    }
    public class AutocadEntity : Entity<PolyLineAdapter>
    {
    }
    public class SketchupEntity : Entity<FaceAdapter>
    {
    }
