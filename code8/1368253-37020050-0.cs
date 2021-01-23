    class SerializingClass
    {
        public readonly Complex1 a;
        public readonly Complex2 b;
        public readonly Complex3 c;
    
        public override bool Equals(System.Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;
            SerializingClass p = obj as SerializingClass;
           
            // Return true if the fields match:
            return a.Id == p.A.Id && b.Id == p.B.Id && c.Id == p.C.Id;
        }
    
        public override int GetHashCode()
        {
            return a.Id ^ b.Id ^ c.Id;
        }
    }
