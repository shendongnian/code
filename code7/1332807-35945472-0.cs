        class ProductPart
        {
            [JsonProperty("$id")]
            public int Id { get; set; }
            public string Name { get; set; }
            [JsonProperty("ProductParts")]
            List<ProductPartsA> ProductPartsA;
        }
        class ProductPartsA
        {
            [JsonProperty("$id")]
            public int Id { get; set; }
            public string Name { get; set; }
            [JsonProperty("ProductParts")]
            List<ProductPartsB> ProductPartsB;
        }
        class ProductPartsB
        {
            [JsonProperty("$id")]
            public int Id { get; set; }
            public string Name { get; set; }
            [JsonProperty("$values")]
            List<Values> Values;
        }
        class Values
        {
            [JsonProperty("$id")]
            public int Id { get; set; }
            public Reference MaterialReference { get; set; }
            public Reference ColorReference { get; set; }
            public Reference ActiveStateReference { get; set; }
        }
        class Reference
        {
            [JsonProperty("$ref")]
            public string Ref { get; set; }
        }
