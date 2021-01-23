     public class Base
        {
            public int x { get; protected set; }
            public int y { get; protected  set; }
    
            /// <summary>
            /// One constructor which set all properties
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Base(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
    
            /// <summary>
            /// Constructor which init porperties from other class
            /// </summary>
            /// <param name="baseClass"></param>
            public Base(Base baseClass) : this(baseClass.x, baseClass.y)
            {
            }
    
            /// <summary>
            ///  May be more secured constructor because you always can check input parameter for null
            /// </summary>
            /// <param name="baseClass"></param>
            //public Base(Base baseClass)
            //{
            //    if (baseClass == null)
            //    {
            //        return;
            //    }
    
            //    this.x = baseClass.x;
            //    this.y = baseClass.y;
            //}
        }
    
        public sealed class A : Base
        {
            // Don't know if you really need this one
            public A(int x, int y) : base(x, y)
            {
            }
    
            public A(A a) : base(a)
            {
            }
    
            public A SetX(int nextX)
            {
                // Create manual copy of object and then set another value
                var a = new A(this)
                {
                    x = nextX
                };
    
                return a;
            }
    
            public A SetY(int nextY)
            {
                // Create manual copy of object and then set another value
                var a = new A(this)
                {
                    y = nextY
                };
    
                return a;
            }
        }
