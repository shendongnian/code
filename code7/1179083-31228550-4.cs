	public static void DisplayShapes_BAD(){
	
		foreach(var item in Shapes)
		{
			if(typeof(Circle) == item.GetType())
			{
				((Circle)item).Display();
			}
			if(typeof(Rectangle) == item.GetType())
			{
				((Circle)item).Display();
			}
		}
	}
