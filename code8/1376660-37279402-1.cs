    private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e) 
	{
       Brush foreColour;
       Brush backColour;
       if (e.Node.IsSelected) 
	   {
          if (e.Node.Text == "Node1") 
		  {
              // Special highlight colouring 
              foreColour = Brushes.Yellow;
              backColour = Brushes.Red;
          }
          else 
		  {
              // Default highlight colouring 
              foreColour = SystemBrushes.HighlightText;
              backColour = SystemBrushes.Highlight;
          }
       }
       else {
          if (e.Node.Text == "Node1") 
		  {
             // Special colouring 
             foreColour = Brushes.Red;
             backColour = Brushes.Yellow;
          }
          else 
		  {
             // Default colouring 
             foreColour = SystemBrushes.WindowText;
             backColour = SystemBrushes.Window;
          }
       }
       e.Graphics.FillRectangle(backColour, e.Bounds);
       e.Graphics.DrawString(e.Node.Text, treeView1.Font, foreColour, e.Bounds);
    }  
	
