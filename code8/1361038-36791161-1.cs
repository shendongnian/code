    public class GetTable
    {
    	public T GetEntities<T>(DbContext context, string agenttype)where T : class, IMstTuver
    	{
    		long maxVersion = context.Set<T>().Max(x => x.MaxVersion);
    		IMstTuver mstTuver = context.Set<T>().Where(x => x.MaxVersion == maxVersion && x.AgentType == agenttype).FirstOrDefault();
    		return mstTuver;
    	}
    }
