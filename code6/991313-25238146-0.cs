    [ProtoContract]
    public class A
    {
        [ProtoMember(1)]
        private string m_OptionsEncrypted;
        private Options mOptions;
        public Options Options 
        {
            get { return mOptions; }
            set { mOptions = new Options(value); }
        }
        [ProtoBeforeSerialization]
        private void OnSerializing()
        {
            m_OptionsEncrypted = Encrypt(mOptions);
        }
        [ProtoAfterDeserialization]
        private void OnDeserialized()
        {
            mOptions = Decrypt(m_OptionsEncrypted);
        }
    };
