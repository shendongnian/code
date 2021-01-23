    [Property]
    public Property XUnitPropertyWithStronglyTypedArbitrary()
    {
        return Prop.ForAll(
            VideoArbitrary.Videos(),
            video =>
            {
                // Test goes here...
                Assert.NotNull(video);
            });
    }
