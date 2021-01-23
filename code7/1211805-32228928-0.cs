    public class CartRepositoryFactory : IRepositoryFactory<DettaglioCarrello, CartContext>
        {
            public IRepository<DettaglioCarrello, CartContext> Generate(CartContext ctx)
            {
                return new CartRepository(ctx);
            }
        }
