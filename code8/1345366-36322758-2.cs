    [TestMethod]
    public void GetClassesWithAttribute()
    {
        var finder = new FindsClassesByAttributeAndEnumValue();
        var types = finder.FindClassesInAssemblyContaining<ReferencesEnumAttribute>(AttributeTypes.TypeA);
        Assert.AreEqual(2, types.Length);
    }
