    public class LogProductCommandHandler : ICommandHandler<LogProduct>
    {
        private readonly IRepository<Product> productRespository;
        private readonly ISimpleLogger[] loggers;
        public LogProductCommandHandler(IRepository<Product> productRespository,
            ISimpleLogger[] loggers) {
            this.productRespository = productRespository;
            this.loggers = loggers;
        }
        public void Handle(LogProduct command) {
            Product product = this.productRepository.GetById(command.ProductId);
            product.TestLog(this.loggers);
        }
    }
