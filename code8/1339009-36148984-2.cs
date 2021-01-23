    [Test]
    public void Content_WhenModifierIsXXX_ReturnsSomeViewModel()
    {
        var viewModel = new EditorViewModel();
    
        viewModel.SetIdentifier("XXX").Wait();
    
        Assert.That(viewModel.Content, Is.InstanceOf<ISomeContentViewModel>());
    }
