    void findEdgeTiles()
	{
		List<int> edgeRow = new List<int>();
		List<int> edgeCol = new List<int>();
		int dir = 0;
		//get starting point
		for(row = 0; row < stationWidth-1; row++)
		{
			for(col = 0; col < stationHeight-1; col++)
			{
				if(roomType[row,col] != (int)room.None)
				{
					edgeRow.Add(row);
					edgeCol.Add(col);
					break;
				}
			}
			if(roomType[row,col] != (int)room.None)
			{
				break;
			}
		}
		//north = 0, east = 1, south = 2, west = 3, minus to turn left, plus to turn right
		//turn left
		dir = (dir+3)%4;
		//move left
		row--;
		Debug.Log("Moved to: "+ row + "," + col);
		while(row != edgeRow[0] || col != edgeCol[0] || edgeCol.Count == 1)
		{
			//turn left or right
			if(roomType[row,col] != (int)room.None)
			{
				//add edge tile as long as there is space beside it
				if(roomType[row+1,col] ==  (int)room.None || roomType[row,col+1] ==  (int)room.None || roomType[row-1,col] ==  (int)room.None || roomType[row,col-1] ==  (int)room.None)
				{
					edgeRow.Add(row);
					edgeCol.Add(col);
				}
				//turn left
				dir = (dir+3)%4;
			}
			else if(roomType[row,col] == (int)room.None)
			{
				//turn right
				dir = (dir+1)%4;
			}
			//move forward
			moveDirection(ref dir);
		}
	}
	void moveDirection(ref int dir)
	{
		if(dir == 0)
		{
			col++;
		}
		if(dir == 1)
		{
			row++;
		}
		if(dir == 2)
		{
			col--;
		}
		if(dir == 3)
		{
			row--;
		}
	}
     
