    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ShopifyAPIAdapterLibrary;
    using System.Configuration;
    using System.Web.Services;
    
    namespace SampleWebApplication
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                ShopifyAuthorizationState state = HttpContext.Current.Session["Shopify.AuthState"] as ShopifyAuthorizationState;
                ShopifyAPIClient client
                    = new ShopifyAPIClient(state);
                string shopData = (string)client.Get("/admin/products.json");
                JavascriptSerializer serializer = new JavascriptSerializer();
                // Here Product is a object class which contains all of the attribute that JSON has.
                List<Product> lstProduct = serializer(shopData);
                GridView1.DataSource = lstProduct;
                GridView1.DataBind();
            }
        }
    }
