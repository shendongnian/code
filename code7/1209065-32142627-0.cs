        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,  UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Json)]
        public Product GetProduct(string id)
        {
            int ID = Convert.ToInt32(id);
            Product selectedProduct = db.Products.Find(ID);
            return selectedProduct;
        }
