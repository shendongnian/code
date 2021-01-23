    var colorPallete = new string[]
    {
    	"Red", "Green", "Blue"
    };
    
    var list = new List<MyModel>()
    {
    	new MyModel() { ID = 1, Name = "model1", Class = "A", },
    	new MyModel() { ID = 2, Name = "model2", Class = "B", },
    	new MyModel() { ID = 3, Name = "model3", Class = "C", },
    };
    
    list.ForEach(x => x.Color = colorPallete.ElementAtOrDefault(x.ID - 1));
