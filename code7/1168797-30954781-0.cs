    [TestMethod]
    public void InheritanceInterface_Test_WithMoq()
    {
        string golfmodel = "gti";
        var golfMock = new Moq.Mock<Golf>(golfmodel);
        golfMock.CallBase = true;  // Tell the mock to call base methods
        var gti = golfMock.Object;
        var safeVehicle = gti as IVehicle;
        var vehicle = (IVehicle)gti;
        var safeCar = gti as ICar;
        var car = (ICar)gti;
    
        Assert.AreEqual(golfmodel, gti.Model, string.Format(" Model:{0} | Golf Model:{1}", golfmodel, gti.Model));
        Assert.AreEqual(gti.Model, safeVehicle.Model, string.Format("Golf Model:{0} | Vehicle Model:{1}", gti.Model, safeVehicle.Model));
        Assert.AreEqual(gti.Model, vehicle.Model, string.Format("Golf Model:{0} | Vehicle Model:{1}", gti.Model, vehicle.Model));
        Assert.AreEqual(gti.Model, safeCar.Model, string.Format("Golf Model:{0} | Carro Model:{1}", gti.Model, safeCar.Model));
        Assert.AreEqual(gti.Model, car.Model, string.Format("Golf Model:{0} | Carro Model:{1}", gti.Model, car.Model));
    }
