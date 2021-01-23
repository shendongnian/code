    private async Task getAllProductDetails()
        {
            var resultproductlist = await client.PostAsync(session.Values["URL"] + "/magemobpos/product/getProductList", contents);
            if (resultproductlist.IsSuccessStatusCode)
            {
                string trys = resultproductlist.Content.ReadAsStringAsync().Result;
                List<Productlistdata> objProducts = JsonConvert.DeserializeObject<ProductlistResponse>(trys).productlistdata;
                
                //all product are in objProducts
                foreach (var item in objProducts)
                {
                    Productlistdata Product = new Productlistdata()
                    {
                        image = item.image,
                        name = item.name,
                        price = item.price,
                        sku = item.sku,
                        type = item.type[0],
                        id = item.id
                    };
                    Product.CheckImage();
                    Productlist.Add(Product);
                }
            }
        }
 
