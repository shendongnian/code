            var mostPopFunc = svcHist.Collection.Function("MostPopular");
            mostPopFunc.Parameter<DateTime>("From");
            mostPopFunc.CollectionParameter<ServiceCodes>("ServiceCodes");
            mostPopFunc.CollectionParameter<int>("ServiceUnits");
            mostPopFunc.Parameter<string>("SearchCCL");
            mostPopFunc.Parameter<int>("ListLength").OptionalParameter = true;
            mostPopFunc.ReturnsCollection<ciExternalPartnerPopularResult.MarcIdPopularity>();
