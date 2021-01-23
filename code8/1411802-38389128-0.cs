    public interface IProtocoll {
       
        IProtocollStateController ProtocollController { get; set; }
    
        void WriteProtocoll(string action, string message, bool? result, Guid conditionId);
        
        void WriteProtocoll(Protocoll protocoll);
        
        List<Protocoll> GetAllProtocoll();
      }
