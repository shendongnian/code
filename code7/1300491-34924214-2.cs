	    private void panel1_DragDrop(object sender, DragEventArgs e)
	    {
	    	Control newControl = null;
	    	// you would really use a better design pattern to do this, but
	    	// for demo purposes I'm using a switch statement
	    	string selectedItem = e.Data.GetData(DataFormats.Text) as string;
	    	switch (selectedItem)
	    	{
	    		case "My Custom Control":
	    			newControl = new CustomControl();
		    		newControl.Location = panel1.PointToClient(new Point(e.X, e.Y));
		    		newControl.Size = new System.Drawing.Size(75, 23);
		    		break;
		    }
		    if (newControl != null) panel1.Controls.Add(newControl);
	    }
