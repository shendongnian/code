        public enum ObjectType
    {
        A = 1,
        B = 2,
        C = 3,
        D=4,
        E=5
    }
    public enum GroupType
    {
        AB=1,
        C=2,
        DE=3,
    }
    public static class EnumTypeOf
    {
        public static GroupType GetGroupType(this ObjectType type)
        {
            switch (type)
            {
                case ObjectType.A:
                case ObjectType.B:
                    return GroupType.AB;
                case ObjectType.C:
                    return GroupType.C;
                case ObjectType.D:
                case ObjectType.E:
                    return GroupType.DE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public static bool IsGroupAb(this ObjectType type)
        {
           return type.GetGroupType() == GroupType.AB;
        }
    }
