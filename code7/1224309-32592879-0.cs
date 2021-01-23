    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace Test.Lib.Base
    {
        public class PageBase : System.Web.UI.Page
        {
            #region Method
            protected override void OnInit(EventArgs e)
            {
                AutocompleteOff();
                base.OnInit(e);
                if (User.Identity.IsAuthenticated)
                    ViewStateUserKey = Session.SessionID;
            }
            protected override void AutocompleteOff()
            {
                Page.Form.Attributes.Add("autocomplete", "off");
            }
            #endregion
        }
    }
