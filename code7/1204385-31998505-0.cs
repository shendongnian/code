    namespace FacebookPlusPlus
    {
        public class AppConfig
        {
            ...
            [Serializable]
            public class SerializableConfig
            {
                public string m_AccessToken;
                public bool m_AutoConnect;
            }
    
            private AppConfig() 
            {
                throw new InvalidOperationException("AppConfig Ctor Invoked");
            }
    
            ...
        }
    }
