    protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Session["session_id"] = id;
        }
        [WebMethod(EnableSession = true)]
        public static List<Product> get_product()
        {
            product_detail get = new product_detail();
            ProductModel db = new ProductModel();
            //List<Product> product = new List<Product>();
            int id = Convert.ToInt32(HttpContext.Current.Session["session_id"]);
            List<Product> product = db.get_product(id);
            return product;
        }
    }
