    public void Test()
    {
        var cv = new ClaimView {Type = "type", Value = "val", ValueType = "string"};
        var claim = Mapper.Map<ClaimView, Claim>(cv);
            
        Assert.AreEqual("type", claim.Type);
        Assert.AreEqual("val", claim.Value);
        Assert.AreEqual("string", claim.ValueType);
    }
