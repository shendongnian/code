    public class RateLimiter
    {
       private readonly double numItems;
       private readonly double ratePerSecond;
       private readonly ConcurrentDictionary<object, RateInfo> rateTable = 
                                 new ConcurrentDictionary<object, RateInfo>();
       private readonly double timePeriod;
    
       public RateLimiter(double numItems, double timePeriod)
       {
           this.timePeriod = timePeriod;
           this.numItems = numItems;
           ratePerSecond = numItems / timePeriod;
       }
    
       public double Count
       {
           get
           {
               return numItems;
           }
       }
    
       public double Per
       {
           get
           {
               return timePeriod;
           }
       }
    
       public bool IsPermitted(object key)
       {
           var permitted = true;
           var now = DateTime.UtcNow;
    		
    		rateTable.AddOrUpdate(
    			key,
    			k => new RateInfo(now, numItems - 1d),
    			(k, rateInfo) => {
    				var timePassedSeconds = 
                                      (now - rateInfo.LastCheckTime).TotalSeconds;
    				var newAllowance = 
                                      Math.Min(rateInfo.Allowance 
                                                + timePassedSeconds 
                                                * ratePerSecond,
    					       numItems);
    				if (newAllowance < 1d)
    				{
    					permitted = false;
    				}
    				else
    				{
    					newAllowance -= 1d;
    				}
    				return new RateInfo(now, newAllowance);
    			});
    		var expiredKeys = rateTable
                   .Where(kvp => 
                       (now - kvp.Value.LastCheckTime) > 
                       TimeSpan.FromSeconds(timePeriod))
                   .Select(k => k.Key);
    		foreach (var expiredKey in expiredKeys)
    		{
    			Reset(expiredKey);
    		}
    
           return permitted;
       }
    
       public void Reset(object key)
       {
    		RateInfo rr;
    		rateTable.TryRemove(key,out rr);
       }
    
    
       internal struct RateInfo
       {
           private readonly double allowance;
           private readonly DateTime lastCheckTime;
    
           public RateInfo(DateTime lastCheckTime, double allowance)
           {
               this.lastCheckTime = lastCheckTime;
               this.allowance = allowance;
           }
    
           public DateTime LastCheckTime
           {
               get
               {
                   return lastCheckTime;
               }
           }
    
           public double Allowance
           {
               get
               {
                   return allowance;
               }
           }
       }
    }
