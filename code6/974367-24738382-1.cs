    public class RentCarCommandHandler : ICommandHandler<RentCarCommand>
    {
        private readonly IUnitOfWork uow;
        public RentCarCommandHandler(IUnitOfWork uow) {
            this.uow = uow;
        }
        public void Handle(RentCarCommand command) {
            // Business logic of your old CarsService.RentCar method here.
        }
    }
