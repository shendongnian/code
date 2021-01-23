    public partial class Page1 : System.Web.UI.Page {
  	  List<Products>     Products     = null ;
	  List<ShoppingCart> ShoppingCart = null ;
    
      protected void Page_Load( object sender, EventArgs e ) {
        if ( !Page.IsPostBack ) {
		  Cache[ "Products" ] = new List<Products>;
  		  Cache[ "ShoppingCart" ] = new List<ShoppingCart>;
          Products     = ( List<Products> )     Cache["Products"];
          ShoppingCart = ( List<ShoppingCart> ) Cache["ShoppingCart"];
        }
      }
    }
