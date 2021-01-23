    [AttributeUsage(AttributeTargets.Class)]
    public class PartTypeAttribute : Attribute
    {
        public readonly PartType PartType;
        public PartTypeAttribute(PartType partType)
        {
            PartType = partType;
        }
    }
