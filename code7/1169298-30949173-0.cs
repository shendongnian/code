    public class EnablePagedQueryAttribute : EnableQueryAttribute
    {
        public EnablePagedQueryAttribute()
        {
            int myPageSizeFromWebConfig = 0;
            // Get value from web.config as you want:
            if (int.TryParse(ConfigurationManager.AppSettings["myPageSize"], out myPageSizeFromWebConfig))
            {
                this.PageSize = myPageSizeFromWebConfig;
            }
        }
    }
