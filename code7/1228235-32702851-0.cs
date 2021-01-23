     // that initialization can be shared
     var container = new UnityContainer();
     // register all mocks (i.e. created with Moq)
     container.RegisterInstnce<IDocumentDbService>(Mock.Of<IDocumentDbService> ());
 
     // resolve your class under test 
     var documentService = container.Resolve<DocumentService>();
     Assert.AreEqual(42, documentService.GetSomething());
