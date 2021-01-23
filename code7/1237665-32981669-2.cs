    [XmlType]
    public class BlockType
    {
        [XmlAttribute]
        public BaseBlockType baseType;
        [XmlIgnore]
        public System.Enum subType;
        [XmlElement("subType")]
        public XmlEnumWrapper XmlSubTypeWrapper
        {
            get
            {
                return (subType == null ? null : new XmlEnumWrapper { Value = subType });
            }
            set
            {
                subType = (value == null ? null : value.Value);
            }
        }
        public BlockType(BaseBlockType baseT, System.Enum subT)
        {
            //Set base type
            baseType = baseT;
            //Set sub type
            subType = subT;
            //possibly need to perform checks that sub-type is acceptable
        }
        public BlockType(BaseBlockType baseT)
        {
            //Set base type
            baseType = baseT;
            //Set sub type
            subType = RandSubType(baseType);
        }
        public BlockType(bool random)
        {
            if (random)
            {
                //Set base type
                int enumLength = System.Enum.GetValues(typeof(BaseBlockType)).Length;
                int rand = Random.Range(0, enumLength);
                baseType = (BaseBlockType)rand;
                //Set sub type
                subType = RandSubType(baseType);
            }
        }
        public BlockType()
        { }
        public System.Enum RandSubType(BaseBlockType baseType)
        {
            int subEnumLength;
            int subRand;
            switch (baseType)
            {
                case BaseBlockType.Animals:
                    subEnumLength = System.Enum.GetValues(typeof(AnimalType)).Length;
                    subRand = Random.Range(0, subEnumLength);
                    return (AnimalType)subRand;
                case BaseBlockType.Geometry:
                    subEnumLength = System.Enum.GetValues(typeof(GeometaryType)).Length;
                    subRand = Random.Range(0, subEnumLength);
                    return (GeometaryType)subRand;
                case BaseBlockType.Letters:
                    subEnumLength = System.Enum.GetValues(typeof(LetterBlockType)).Length;
                    subRand = Random.Range(0, subEnumLength);
                    return (LetterBlockType)subRand;
                default:
                    Debug.WriteLine("Block Sub Type Selection not working");
                    return null;
            }
        }
        public override string ToString()
        {
            string result = baseType.ToString() + "." + subType.ToString();
            return result;
        }
        public override bool Equals(object t)
        {
            var test = t as BlockType;
            if (t == null)
                return false;
            return (test.baseType == this.baseType && test.subType == this.subType);
        }
        public override int GetHashCode()
        {
            var code1 = baseType.GetHashCode();
            var code2 = subType == null ? 0 : subType.GetHashCode();
            return unchecked(~code1 ^ (7 + code2 << 3));
        }
    }
