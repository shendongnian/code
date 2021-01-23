    using System.Web.UI.Adapters;
     public class ServerSideViewStateAdapter:PageAdapter
        {
            public override PageStatePersister GetStatePersister()
            {
               // return base.GetStatePersister();
                return new SessionPageStatePersister(this.Page);
            }
            
        }
