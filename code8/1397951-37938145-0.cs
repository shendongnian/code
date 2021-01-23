    [TestMethod]
    public void ProductImageConfiguration_Verification_With_ProductItemViewModel()
    {
        chooseProduct = new ChooseProductViewModel(productRepository, categoryRepository, eventAggregator, posDeviceSettings);
        var productItemViewModel = chooseProduct.Items.First() as ProductItemViewModel; //This line will obviously produce null
        Assert.IsNotNull(productItemViewModel);
        Assert.IsTrue(productItemViewModel.hasProductImages);
    }
