    public interface ITransferSomething {
      // anything here as long as it is decorated with [Serializable]
      IList<vw_ServiceandProduct> SerializableValue { get; }
      // exposing standard property of System.Web.UI.Page
      bool IsCrossPagePostBack { get; }
    }  
    
