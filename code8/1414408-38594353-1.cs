    [ModelBinder(typeof(UpdateProductModelBinder))]
    public class UpdateProductModel {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
