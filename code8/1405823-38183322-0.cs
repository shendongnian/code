            Mapper.CreateMap<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>();
            var obj = Mapper.Map<IEnumerable<CatalogueDefinitionFileViewModel>>(new List<CatalogueDefinitionFile>{
                new CatalogueDefinitionFile
            {
                Id = 101,
                Name = "test",
                TargetApplication = "test",
                IsActive = false,
                CreatedBy = "test",
                CreatedDate = DateTime.Now,
                UpdatedBy = "test",
                UpdatedDate = DateTime.Now,
                ProductDefinitions = new List<ProductDefinition> { new ProductDefinition { MyProperty = 100 } }}
            });
