    public class YourBaseClass<T>
        where T: class
    {
        public T Point { get; set; }
    }
    
    public class A : YourBaseClass<Point2D>
    {
    }
    
    public class B : YourBaseClass<Point3D>
    {
    }
