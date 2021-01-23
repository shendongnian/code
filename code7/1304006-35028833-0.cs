	List<ShapeObj> ShapeObj_list; //The list of objects drawn.
	private void OnMouseDown(object sender, MouseEventArgs e)
	{
		foreach(ShapeObj obj in ShapeObj_list)
		{
			if(obj.InsideTheObject(e.X, e.Y))
			{
				//Do Something
			}
		}
	}
