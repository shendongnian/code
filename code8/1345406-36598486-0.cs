    using System;
    
    using CMS.Helpers;
    using CMS.PortalControls;
    using CMS.PortalEngine;
    
    public partial class CMSWebParts_General_RandomRedirection : CMSAbstractWebPart
    {
        #region Webpart properties
    
        /// <summary>
        /// URL to redirect if the query value is not correct.
        /// </summary>
        public string RedirectionURL
        {
            get
            {
                return ValidationHelper.GetString(GetValue("RedirectionURL"), "");
            }
            set
            {
                SetValue("RedirectionURL", value);
            }
        }
    
        #endregion
    
    
        #region Webpart methods
    
        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
        }
    
    
        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            if (!StopProcessing)
            {
                if ((RedirectionURL.Trim().Length > 0) &&
                    PortalContext.ViewMode.IsLiveSite())
                {
                    string newURL = URLHelper.ResolveUrl(RedirectionURL.Trim());
                    if ((RequestContext.CurrentURL != newURL) &&
                        (URLHelper.GetAbsoluteUrl(RequestContext.CurrentURL) != newURL))
                    {
                        var value = QueryHelper.GetString("queryName", String.Empty);
                        //Test value of your query parameter
                        if (!value.Equals("queryValue"))
                        {
                            newURL = URLHelper.RemoveParameterFromUrl(newURL, "queryName");
                            URLHelper.ResponseRedirect(newURL);
                        }
                    }
                }
            }
        }
    
    
        /// <summary>
        /// Reloads the control data.
        /// </summary>
        public override void ReloadData()
        {
            base.ReloadData();
            SetupControl();
        }
    
        #endregion
    }
