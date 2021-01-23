    public List<ColorList> GetColorsList()
    {
        var result = new List<ColorList> () {
                new ColorList { ColorCode = 0, ColorName = "Green" },
                new ColorList { ColorCode = 1, ColorName = "Yellow" },
                new ColorList { ColorCode = 2, ColorName = "Yellow Audible" }
            };
        return result;
    }
