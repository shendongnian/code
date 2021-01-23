    public class DoNotSerializeMe
    {
        public readonly string WhyAmIHere;
        readonly bool ProperlyConstructed; // data contract serializer does not call the constructor
        public DoNotSerializeMe(string mystring)
        {
            Console.WriteLine(string.Format("    In DoNotSerializeMe constructor, mystring = \"{0}\"", mystring));
            WhyAmIHere = mystring;
            ProperlyConstructed = true;
        }
        public void Validate()
        {
            if (!ProperlyConstructed)
                throw new InvalidOperationException("!ProperlyConstructed");
        }
    }
    public class SerializeMe
    {
        [IgnoreDataMember]
        public DoNotSerializeMe CannotBeSerializedDirectly;
        public DoNotSerializeMeSurrogate DoNotSerializeMeSurrogate
        {
            get
            {
                if (CannotBeSerializedDirectly == null)
                    return null;
                return new DoNotSerializeMeSurrogate { WhyAmIHereSurrogate = CannotBeSerializedDirectly.WhyAmIHere };
            }
            set
            {
                if (value == null)
                    CannotBeSerializedDirectly = null;
                else
                    CannotBeSerializedDirectly = new DoNotSerializeMe(value.WhyAmIHereSurrogate);
            }
        }
        public string SomeOtherField { get; set; }
    }
    public class DoNotSerializeMeSurrogate
    {
        public string WhyAmIHereSurrogate { get; set; }
    }
