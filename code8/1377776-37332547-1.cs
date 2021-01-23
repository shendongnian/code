    public partial class Page2 : System.Web.UI.Page {
      List<Products>     Products     = null ;
  	  List<ShoppingCart> ShoppingCart = null ;
      protected void Page_Load( object sender, EventArgs e ) {
        // be sure to check for null
        Products     = ( List<Products> )     Cache["Products"];
  	    ShoppingCart = ( List<ShoppingCart> ) Cache["ShoppingCart"];
      }
    }
