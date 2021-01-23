    public class ProductModel
    {
        [ModelBinder(BinderType = typeof(RangeModelBinder))]
        public Filter<double> Price { get; set; }
    }
