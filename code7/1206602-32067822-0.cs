     public class Vertex
        {
            public virtual int Number { set; get; }
            public virtual int X { set; get; }
            public virtual int Y { set; get; }
            public virtual Polygon Polygon { set; get; }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
    
                Vertex V = (Vertex)obj;
                if (V == null)
                    return false;
    
                if (Number == V.Number && Polygon.Id == V.Polygon.Id)
                    return true;
    
                return false;
            }
    
            public override int GetHashCode()
            {
                return (Number + "|" + Polygon.Id).GetHashCode();
            }
    
        }
