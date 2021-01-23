            var chair = new Furniture
            {
                Name = "chair",
                RawMaterials = new List<RawMaterial>
                {
                    new RawMaterial {
                        Name = "paint",
                        FurnitureId = 1
                    },
                    new RawMaterial {
                        Name = "wood",
                        FurnitureId = 1
                    },
                }
            };
            var coffeeTable = new Furniture
            {
                Name = "coffee table",
                RawMaterials = new List<RawMaterial>
                {
                    new RawMaterial {
                        Name = "glass",
                        FurnitureId = 2
                    },
                    new RawMaterial {
                        Name = "wood",
                        FurnitureId = 2
                    },
                }
            };
            context.Furnitures.AddRange(new Furniture[] { chair, coffeeTable });
            context.SaveChanges();
