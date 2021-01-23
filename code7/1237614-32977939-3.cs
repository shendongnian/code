    public class MyModel
    {
        private Properties _properties;
        private Extensions _ extensions;
     
        public MyModel(Properties properties, Extensions extensions)
        {
            _properties = properties;
            _extensions = extensions;
        }
    
        public Properties Prop
        {
            get { return _properties; }
        }
        public Extensions Ext
        {
            get { return _extensions; }
        }
    }
