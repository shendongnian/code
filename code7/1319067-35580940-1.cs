    this.For<ITemplatingService>()
                .Singleton()
                .Add<TemplatingService>()
                .Named("invoiceTemplates")
                .Ctor<Assembly>("assembly").Is(billingDocumentGeneratorAssembly)
                .Ctor<string>("templatesNamespace").Is("MyBillingNamespace.DocumentGenerator.Invoices.Templates");
