    [Test]
    public void TestSerialization()
    {
        var cart = new Cart()
        {
            id = "944990015513953203",
            quantity = "3",
            modifier = new CartModifier()
            {
                Values =
                {
                   {"1033306667720114200", 1033308953984892900}
                }
            }
        };
        Console.WriteLine(JsonConvert.SerializeObject(cart));
    }
    
    [Test]
    public void TestDeseriazliation()
    {
        var data = "{\"cartId\":null, \"id\":\"944990015513953203\",\"quantity\":\"3\",\"modifier\":{ \"1033306667720114200\":1033308953984892900 }}";
        var cart = JsonConvert.DeserializeObject<Cart>(data);
        Assert.AreEqual(cart.modifier.Values["1033306667720114200"], 1033308953984892900);
    }
