    var colorPallete = new string[]
    {
    	"Red", "Green", "Blue"
    };
    
    var list = new List<MyModel>()
    {
    	new MyModel() { ID = 1, Name = "model1", Class = "A", },
    		new MyModel() { ID = 1, Name = "model11", Class = "AA", },
    		new MyModel() { ID = 2, Name = "model2", Class = "B", },
    		new MyModel() { ID = 3, Name = "model3", Class = "C", },							
    		new MyModel() { ID = 4, Name = "model4", Class = "D", },
    		new MyModel() { ID = 5, Name = "model5", Class = "E", },			
    };
    
    //A. This code assigns null for unknown IDs
    //I.e. if (ID > 0 && ID < colorPallete.Length) then color will be picked from colorPallete[],
    //else it will be null
    list.ForEach(x => x.Color = colorPallete.ElementAtOrDefault(x.ID - 1));
    
    //B. This code apply some default color for unknown IDs
    //I.e. if (ID > 0 && ID < colorPallete.Length) then color will be picked from colorPallete,
    //else it will be "DefaultColor"
    list.ForEach(x => x.Color = colorPallete.ElementAtOrDefault(x.ID - 1) ?? "DefaultColor");
    
    //C. This code can assign the same color to models with different IDs, 
    //but models with identical IDs always will have identical color
    list.ForEach(x => x.Color = colorPallete.ElementAtOrDefault((x.ID - 1) % colorPallete.Length));
