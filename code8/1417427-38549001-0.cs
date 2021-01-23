    public enum ObjectType
        {
            A = 1,
            B = 2,
            C = 3,
        }
    
        public static class EnumTypeOf
        {
            public static bool IsTypeAorB(this ObjectType type)
            {
                switch (type)
                {
                    case ObjectType.A:
                    case ObjectType.B:
                        return true;
                    case ObjectType.C:
                        return false;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
    
            public static bool Test(ObjectType type)
            {
                return type.IsTypeAorB();
            }
        }
