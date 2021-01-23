     public class SupplierController : Controller
        {
            //the controller doesn't need to create the db context now
            //this concern is handled now by the IoC container
    
            private SupplierService supplierService;
            private RatingService SupplierRatingService;
        
            public SupplierController(SupplierService supplierService, RatingService ratingService)
            {
                // we don't have to pass the db context now to services, since we retrieve the services from the IoC container. The IoC container auto-wires the services 
                this.supplierService = supplierService;
                this.ratingService = ratingService;
            }
            public ActionResult Index(Guid id)
            {
                var supplier = supplierService.getSupplier(id);
                // construct viewmodel
                return new SupplierIndexViewModel()
                {
                    SupplierId = supplier.Id,
                    SupplierName = supplier.Name,
        
                    SupplierRating = ratingService.getHighestRating(supplier.Id),
                    NearbySuppliers = supplierService.getNearbySuppliers(supplier.Id),
                    // etc
                };
            }
            // the controller doesn't need a dispose method since the IoC container will dispose the dbcontext for us
        }
