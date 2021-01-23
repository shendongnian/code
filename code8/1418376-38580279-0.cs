        // added private setters for approach to work
        public X x { get; private set;} 
        public Y y { get; private set;} 
        public class A(X x, Y y) 
        { 
            this.x = x; 
            this.y = y; 
        } 
        private A With(Action<A> update) 
        {
            var clone = (A)MemberwiseClone();
            update(clone);
            return clone;
        } 
        public A SetX(X nextX) 
        { 
            return With(a => a.x = nextX); 
        } 
        public A SetY(Y nextY) 
        { 
            return With(a => a.y = nextY); 
        } 
     }
 
