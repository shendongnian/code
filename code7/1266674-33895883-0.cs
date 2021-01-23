    public class MainDllProject
    {
        ISettings m_Settings;
        
        public MainDllProject()
        {
            // Change this before compiling
            this.m_Settings = new DebugSettings();
            //this.m_Settings = new DeploySettings();
            // use settings from the settings class
            String setting1 = this.m_Settings.Setting1
            Int32 setting2 = this.m_Settings.Setting2
            //...
        }
    }
    public interface ISettings
    {
        String Setting1 { get; }
        Int32 Setting2 { get; }
    }
    public class DebugSettings: ISettings
    {
        public String Setting1
        { get { return "data_debug";} }
        public Int32 Setting2
        { get { return 2;} }
    }
    public class DeploySettings: ISettings
    {
        public String Setting1
        { get { return "data_deploy";} }
        public Int32 Setting2
        { get { return 1;} }
    }
