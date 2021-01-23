    [ProtoContract]
    [ProtoInclude(1, typeof(SubType1))]
    [ProtoInclude(2, typeof(SubType2))]
    public class BaseType {
        static BaseType() {
            // This runs prior to serializers being built,
            //     regardless of which subtype is used first
            RuntimeTypeModel.Default[typeof(SubType1)][1].SupportNull = true;
        }
        ...
    }
    [ProtoContract]
    public class SubType1 : BaseType {
        [ProtoMember(1, OverwriteList = true)]
        public double?[] MyProp { get; set; }
        ...
    }
    [ProtoContract]
    public class SubType2 : BaseType {
        ...
    }
