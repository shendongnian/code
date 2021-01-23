    public class MyObject : MarshalByRefObject
    {
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            Debug.Assert(lease.CurrentState == LeaseState.Initial);
            //Set lease properties 
            lease.InitialLeaseTime = TimeSpan.FromMinutes(30); 
            lease.RenewOnCallTime = TimeSpan.FromMinutes(10); 
            lease.SponsorshipTimeout = TimeSpan.FromMinutes(2); 
            return lease;
        }
    }
