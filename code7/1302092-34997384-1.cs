     public class TipoDeCanalesControllerTest : TestBase
        {
    
    
            [TestMethod]
            public void PostTipoDeCanal()
            {
                TipoDeCanalesController controller = NewController();
    
                // Act
                TipoDeCanal tipoDeCanal = new TipoDeCanal() { Descripcion = "Unit Test Des", Nombre = "Unit Test" };
                var response = new HttpResponseMessage();
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    response = controller.PostTipoDeCanal(tipoDeCanal);
                    ts.Dispose();
                }
    
                // Assert
                Assert.AreEqual(System.Net.HttpStatusCode.Created,
                   response.StatusCode);
            }
