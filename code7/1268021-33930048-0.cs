    string[] cells = new string[] { X1.Text, Y1.Text, Z1.Text, X2.Text, Y2.Text, Z2.Text, X3.Text, Y3.Text, Z3.Text };
    List<string> final_cells = new List<string>();
    //Process array to determine which cells are full, adds full cells to list
    for (int i = 0; i < cells.Length; i++)
    {
      if(cells[i].Length == 0)
      {
       //If cell is empty, continue to the next one
       continue;
      }
      else
      {
       // If cell is full add its contents to the final_cells list
       final_cells.Add(cells[i]);
      }
    }
    //Join the list to one string
    string content = string.Join(">, <", final_cells);
