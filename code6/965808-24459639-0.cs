    public interface IDataManager<T> : IDisposable where T : class
    {
    	T GetById(string id);
    }
    
    public class DataManagerBase : IDisposable
    {
    	protected Find<T>(string id) where T : class
    	{
    		return this.Context.Set<T>().Find(id);
    	}
    }
    
    public class TicketManager : DataManagerBase, IDataManager<TicketResponse>, IDataManager<Ticket>
    {
    	TicketResponse IDataManager<TicketResponse>.GetById(string id)
    	{
    		return this.Find<TicketResponse>(id);
    	}
    	
    	Ticket IDataManager<Ticket>.GetById(string id)
    	{
    		return this.Find<TicketResponse>(id);
    	}
    }
