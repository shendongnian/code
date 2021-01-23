    TipoDeCanalesController TipoDeCanal = new TipoDeCanalesController();
    
    TipoDeCanal.Request = new HttpRequestMessage();
    TipoDeCanal.Request.SetConfiguration(new HttpConfiguration());
    Assert.Equals(TipoDeCanal.PostTipoDeCanal(new Models.TipoDeCanal { Descripcion = "Unit Test Description", Nombre = "Test" }).StatusCode,
                    System.Net.HttpStatusCode.Created);
