    collection.Should().ContainSingle();
    collection.Should().ContainSingle(x => x > 3);
    collection.Should().Contain(8).And.HaveElementAt(2, 5).And.NotBeSubsetOf(new[] {11, 56});
    collection.Should().Contain(x => x > 3); 
    collection.Should().Contain(collection, 5, 6); // It should contain the original items, plus 5 and 6.
