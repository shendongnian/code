    public class Settings {
       private Settings() {
           // Called by XmlDeserializer
       }
    
       private Settings(int dummy) {
           // Called by factory method
           InnerSettings = new List<InnerSettings> { new InnderSettings(); }
       }
    
       public static Settings Create() {
           return new Settings(0);
       }
    }
