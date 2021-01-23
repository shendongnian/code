    using System.IO;
    using System;
    using System.Linq;
    class Vertex
    {
       public float x,y,z;
       
       public Vertex(float _x, float _y,float  _z) {
           x = _x;
           y = _y;
           z = _y;
       }
    
        public static Vertex operator+(Vertex v1, Vertex v2)
         {
          return new Vertex(v1.x+v2.x, v1.y+v2.y, v1.z+v2.z);
         }
    
        public static Vertex[] AddVertices(Vertex[] A, Vertex[] B)
         {
          return A.Zip(B, (v1, v2) => v1 + v2).ToArray();
         }
    
        public override String ToString() { return string.Format("({0}, {1}, {2})",x,y,z);}
    }
    
    
    class Program
    {
        const int some_small_int=2;
        static Vertex[] A=new Vertex[]{ new Vertex(10.0f, 10.0f, 10.0f),new Vertex(10.0f, 10.0f, 10.0f)};
        static Vertex[] B=new Vertex[]{new Vertex(10.0f, 10.0f, 10.0f),new Vertex(10.0f, 10.0f, 10.0f)};
        
        static Vertex[] C= Vertex.AddVertices(A,B);
        
        
        static void Main()
        {
            Console.WriteLine("Vertex Array A:");
            foreach(var vert in A) Console.WriteLine(vert);
    
            Console.WriteLine("Vertex Array B:");
            foreach(var vert in B) Console.WriteLine(vert);
    
            Console.WriteLine("Vertex Array C:");
            foreach(var vert in C) Console.WriteLine(vert);
            
            var vert1 = new Vertex(1,2,3);
            var vert2 = new Vertex(4,5,6);
            var vert3 = vert1 + vert2;
            
            Console.WriteLine("Vertex v1 + v2:" + vert3.ToString());
            
        }
    }
 
