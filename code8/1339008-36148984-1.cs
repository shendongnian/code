    [Test]
    public async void Content_WhenModifierIsXXX_ReturnsSomeViewModel()
    {
        var viewModel = new EditorViewModel();
    
        await viewModel.SetIdentifier("XXX");
    
        Assert.That(viewModel.Content, Is.InstanceOf<ISomeContentViewModel>());
    }
