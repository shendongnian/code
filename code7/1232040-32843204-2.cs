    [Property(Arbitrary = new[] { typeof(VideoArbitrary) })]
    public void XunitPropertyWithWeaklyTypedArbitrary(Video video)
    {
        // Test goes here...
        Assert.NotNull(video);
    }
