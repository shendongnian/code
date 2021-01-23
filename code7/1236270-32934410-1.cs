    class VisitableObject : IVisitable {
        private Object _obj;
    
        public VisitableObject(Object obj) { _obj = obj; }
    
        public void Accept(IVisitor visitor) {
            // These ugly if-else are sign that visitor pattern is not right for your model or you need to revise your model.
            if (_obj.Name == "Method" && _obj.Value == "And") {
                visitor.VisitAnd(obj);
            }
            else if (_obj.Name == "Method" && _obj.Value == "IsEqual") {
                visitor.VisitEquals(obj);
            }
            else
                throw new NotSupportedException();
            }
        }
    }
    
    public static ObjectExt {
        public static IVisitable AsVisitable(this Object obj) {
            return new VisitableObject(obj);
        }
    }
