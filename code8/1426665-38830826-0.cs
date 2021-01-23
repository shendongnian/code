    public class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                RuleFor(product => product.isPremium).NotNull().WithName("isLuxury").OverridePropertyName("isLuxury");
            }
        }
