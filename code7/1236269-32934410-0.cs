    interface IVisitable { void Accept(IVisitor visitor); }
    
    interface IVisitor {
        void VisitAnd(Object obj);
        void VisitEquals(Object obj);
    }
