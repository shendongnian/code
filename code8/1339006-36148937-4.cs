    [Test]
    public async Task Content_WhenModifierIsXXX_ReturnsSomeViewModel()
    {
        Task.Run(async () =>
        {
            var viewModel = new EditorViewModel();
    
            await viewModel.SetIdentifier("XXX");
    
            Assert.That(viewModel.Content, Is.InstanceOf<ISomeContentViewModel>());
        }).GetAwaiter().GetResult();
    }
