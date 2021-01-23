    public class YamlFileConfigurationSource<TConfiguration>
        : IConfigurationSource<TConfiguration> {
        public YamlFileConfigurationSource() { }
        public TConfiguration Current { 
            get {
                String fileName = typeof(TConfiguration).Name + ".config";
                // get config from fileName
            }
        }
    }
