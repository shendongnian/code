    [DataContract]
    [Flags]
    public enum OptionsEnum
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        MyOption1 = 1,
        [EnumMember]
        MyOption2 = 2,
        [EnumMember]
        MyOption3 = 4,
        [EnumMember]
        MyOption4 = 8
    }
    [DataContract]
    [TypeConverter(typeof(FlagsConverter<MyOptionalFlags, OptionsEnum>))]
    public class MyOptionalFlags
        : Flags<OptionsEnum>
    {
        // We don't add anything here, as the whole purpose of this class is to
        // wrap the OptionsEnum in a class that will be instantiated by the
        // attributed FlagsConverter.
    }
    [ServiceContract]
    public interface MyServiceContract
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "resource?options={options}")]
        void MyOperation(MyOptionalFlags options);
    }
    public class MyServiceContractImpl
        : MyServiceContract
    {
        public void MyOperation(MyOptionalFlags options)
        {
            if (options.Value == OptionsEnum.None)
            {
                // We will now get here for requests that do not specify a 
                // value for the options parameter in the URL. Note that just 
                // like for an enum value, we don't have to check if options is
                // null here.
            }
        }
    }
