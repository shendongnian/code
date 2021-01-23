	public class UploadsController : Controller
	{
		[HttpGet]
		public ActionResult Image( string fileName )
		{
			//!validate file name!
			return File( Server.MapPath( $"~/App_Data/{fileName}" ), "image/jpeg" );
		}
	}
