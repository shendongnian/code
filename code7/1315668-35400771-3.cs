    using(var context = new CommonLayer.DBModelEntities()){
     if (od.ProductQuantity > orderDetails.ProductQuantity)
     {
       product.ProductQuantity -= (od.ProductQuantity - orderDetails.ProductQuantity);
       daprod.UpdateProduct(product);
       this.Entities.Entry(orderDetails).CurrentValues.SetValues(od);
     }
     else if (od.ProductQuantity < orderDetails.ProductQuantity)
     {
        product.ProductQuantity += (orderDetails.ProductQuantity - od.ProductQuantity);
        daprod.UpdateProduct(product);
        this.Entities.Entry(orderDetails).CurrentValues.SetValues(od);
     }
     context.SaveChanges();
    }
