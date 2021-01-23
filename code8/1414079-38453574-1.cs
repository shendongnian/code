    public enum ePluginType 
    { 
        UNKNOWN, 
        EXCEL, 
        EXCEL_SM, 
        RTF
    } 
    public interface CommonPluginInterface
    {
        string GetPluginName();
        ePluginType GetPluginType();
        bool ElaborateReport();
    }
    public class PluginReport_Excel : MarshalByRefObject, CommonPluginInterface
    {
        public ePluginType GetPluginType()
        {
            return ePluginType.EXCEL;
        }
        //implement other interface members
    }
