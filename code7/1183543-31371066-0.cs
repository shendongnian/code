    [AttributeUsageAttribute( AttributeTargets.Class | 
                              AttributeTargets.Method, 
                              Inherited = true, AllowMultiple = true )]
    public class CustomAuthorizeAttribute : AuthorizeAttribute {
       public override bool AuthorizeCore( HttpContextBase context ) {
           // this is where you can inspect the principal in context.User
           // and check if he/she is in role
           // you can get the clubId from context.Request.Params
           var clubId = int.Parse( context.Request.Params["clubId"] );
           return context.User.IsInRole( string.Format( "Club{0}Admin", clubId ) );  
       }
    }
