    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using System.Web.Http;
    
    public class ProductsController : ApiController
    {
        // other code omitted for brevity.
        
        [HttpPost]
        public IHttpActionResult PostProduct(ProductModel product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException("Product parameter cannot be null");
                }
    
                if (ModelState.IsValid)
                {
                    // code omitted for brevity.
    
                    return this.Ok();
                }
                else
                {
                    throw new Exception("Product is invalid");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    
        [HttpPut]
        public IHttpActionResult PutProduct(ProductModel product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException("Product parameter cannot be null");
                }
    
                if (ModelState.IsValid && product.Id > 0)
                {
                    // code omitted for brevity.
    
                    return this.Ok();
                }
                else
                {
                    throw new Exception("Product is invalid");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    
        // other code omitted for brevity.
    
    }
