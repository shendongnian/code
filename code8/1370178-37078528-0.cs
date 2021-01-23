    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.UI;
    
    namespace TestWebFormsAutoComplete
    {
        public class SiteList : System.Web.UI.UserControl, IPostBackEventHandler
        {
            public event EventHandler<EventArgs> SiteIDChanged;
    
            public void RaisePostBackEvent(string eventArgument)
            {
                int i = 0;
            }
    
            protected virtual void OnSiteIDChanged(object sender, EventArgs e)
            {
                if (SiteIDChanged != null)
                    SiteIDChanged(sender, e);
            }
        }
    }
