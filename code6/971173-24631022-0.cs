    class Obj
    {
    	public string Text {get;set;}
    	public int Width {get;set;}
    }
    
    void Main()
    {
    	
    	var data = new [] {
    		new Obj { Text = "Hello", Width = 2 },
    		new Obj { Text = "Something else", Width = 1 },
    		new Obj { Text = "Another", Width = 1 },
    		new Obj { Text = "Extra-wide", Width = 3 },
    		new Obj { Text = "Random", Width = 1 }
    	};
    	
    	var maxWidth = data.Max (d => d.Width );
    	var result = data.Batch(maxWidth).ToList();
    	result.Dump(); // Dump is a linqpad method
