    [Theory, AutoAtomData]
    public void WithRelReturnsCorrectResult(
        AtomLink sut,
        string newRel)
    {
        AtomLink actual = sut.WithRel(newRel);
        var expected = sut.AsSource().OfLikeness<AtomLink>()
            .With(x => x.Rel).EqualsWhen(
                (s, d) => object.Equals(newRel, d.Rel));
        expected.ShouldEqual(actual);
    }
