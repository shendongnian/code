    //translation of java code to proper C#
    public abstract class EventHandler ...
    {
        public void Handle (BankingEvent e) 
        {  
            HouseKeeping(e); //this is required by the base class.
            DoHandle(e); //Here, control is delegated to the abstract method.
        }
        protected abstract void DoHandle(BankingEvent e);
    }
 
    public class TransferEventHandler: EventHandler
    {
        protected overridevoid DoHandle(BankingEvent e) 
        {
           initiateTransfer(e);
        }
    }
    
