    public interface IConfigurationFileProvider<TConfiguration> {
        String GetFileName(); 
    }
    public class SimpleConfigurationFileProvider<TConfiguration>
        : IConfigurationFileProvider<TConfiguration>  {
        public String GetFileName() {
            return typeof(TConfiguration) + ".config";
        }
    }
