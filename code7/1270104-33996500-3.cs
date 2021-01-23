    public void Test()
    {
         ClaimIdentityView civ = new ClaimIdentityView
         {
             ClaimViewList = new List<ClaimView> 
                                 {
                                     new ClaimView 
                                     {
                                          Type = "type", 
                                          Value = "val", 
                                          ValueType = "string"
                                      }
                                 }
         };
         var claims = civ.ClaimViewList.Select(Mapper.Map<ClaimView, Claim>).ToList();
         Assert.AreEqual(1, claims.Count);
         Assert.AreEqual("type", claims.Single().Type);
         Assert.AreEqual("val", claims.Single().Value);
         Assert.AreEqual("string", claims.Single().ValueType);
    }
