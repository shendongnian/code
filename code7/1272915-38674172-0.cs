	using ServiceLibrary.Contracts;
	using ServiceModelEx;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.ServiceModel;
	using System.Text;
	using System.Threading.Tasks;
	
	namespace Subscriber
	{
	    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any, IncludeExceptionDetailInFaults = DebugHelper.IncludeExceptionDetailInFaults, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
	    class SubscriptionService : DiscoveryPublishService<IMyEvents>, IMyEvents
	    {
	        public void OnEvent1()
	        {
	            Debug.WriteLine("SubscriptionService OnEvent1");
	        }
	
	        public void OnEvent2(int number)
	        {
	            Debug.WriteLine("SubscriptionService OnEvent2");
	        }
	
	        public void OnEvent3(int number, string text)
	        {
	            Debug.WriteLine("SubscriptionService OnEvent3");
	        }
	    }
	}
