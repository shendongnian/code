    [Fact]
    public void VideoProperty()
    {
        var property = Prop.ForAll(
            VideoArbitrary.Videos(),
            video =>
            {
                // Test goes here...
                Assert.NotNull(video);
            });
        property.QuickCheckThrowOnFailure();
    }
