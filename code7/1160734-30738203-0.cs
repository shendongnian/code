     public static IEdmModel GetServiceModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<BDBODataService.Order>("Orders");
            /* this explicitly Ignores a specific property.
             * notice if you call http://localhost:7428/odata/Products(1)?$expand=Category
             * picture will be hidden */
            var cat = builder.EntitySet<BDBODataService.Category>("Categories");
            cat.EntityType.Ignore(c => c.Picture);
            builder.EntitySet<BDBODataService.CustomerDemographic>("CustomerDemographics");
            builder.EntitySet<BDBODataService.Customer>("Customers");
            builder.EntitySet<BDBODataService.Employee>("Employees");
            builder.EntitySet<BDBODataService.Order_Detail>("OrderDetails");
            builder.EntitySet<BDBODataService.Region>("Regions");
            builder.EntitySet<BDBODataService.Shipper>("Shippers");
            builder.EntitySet<BDBODataService.Supplier>("Suppliers");
            builder.EntitySet<BDBODataService.Territory>("Territories");
            builder.EntitySet<BDBODataService.Orpan>("Orphans");
            var products = builder.EntitySet<BDBODataService.Product>("Products");
            return builder.GetEdmModel();
        }
