    var addOns = new List<AddOn> {
        new AddOn { 
            ID = "1", 
            Quantity = 5, 
            Variations = new List<Variation> 
            {
                new Variation { Code = "A" },
                new Variation { Code = "B" }
            } 
        },
        new AddOn { 
            ID = "2", 
            Quantity = 7, 
            Variations = new List<Variation> 
            {
                new Variation { Code = "B" },
                new Variation { Code = "C" }
            } 
        },
        new AddOn { 
            ID = "3", 
            Quantity = 9, 
            Variations = new List<Variation> 
            {
                new Variation { Code = "D" },
                new Variation { Code = "A" }
            } 
        },
    };
