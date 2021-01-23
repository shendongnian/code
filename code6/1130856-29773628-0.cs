    public class SortDirection
    {
        public string prop { get; set; }
        public string direction { get; set; }
    }
    public class CampaignModel
    {
        public int id { get; set; }
        public string post { get; set; }
        public string description { get; set; }
    }
    public class SortModelBinder
        :System.Web.Mvc.IModelBinder
    {
        Type currType = typeof( CampaignModel );
        public object BindModel( ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext )
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            var retVal = new SortDirection();
            foreach( var prop in currType.GetProperties() )
            {
                string dir = request.Form.Get( string.Format( "sort[{0}]", prop.Name ) );
                if( !string.IsNullOrEmpty( dir ) )
                {
                    retVal.prop = prop.Name;
                    retVal.direction = dir;
                }
            }
            return retVal;
        }
    }
    public ActionResult OrganizationPosts( int current, int rowCount, [ModelBinder( typeof( SortModelBinder ) )] SortDirection sort, string sender = null, string searchPhrase = null )
        {           
    ...
        } 
