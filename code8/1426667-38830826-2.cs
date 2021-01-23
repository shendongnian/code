    public class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                RuleFor(product => product.isPremium).NotNull().OverridePropertyName("isLuxury");
            }
        }
