    public class HomeController : Controller
    {
      [HttpPost]
      public void Upload( )
      {
        for( int i = 0 ; i < Request.Files.Count ; i++ )
        {
          var file = Request.Files[i];
          var fileName = Path.GetFileName( file.FileName );
          var path = Path.Combine( Server.MapPath( "~/[Your_Folder_Name]/" ) , fileName );
          
          file.SaveAs( path );    
        }
      }
    }
