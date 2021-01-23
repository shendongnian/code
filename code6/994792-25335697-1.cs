     [TestMethod]
     public void Create_PutProductInRepository()
     {      
         int testId = 3;     
         ...
         var result = controller.PutProduct(testId, inputProduct) as StatusCodeResult;
         ...
         // This is the kind of testing you really want to be doing.
         //  You want to "assert that the item exists in the database and has the expected value"
         Product productAfterTest = mockrepository.GetProduct(testId);
         Assert.AreEqual(inputProduct.Price, productAfterTest.Price);
     }
