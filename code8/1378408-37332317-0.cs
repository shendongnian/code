    private void MyCanvasComponent_MouseDown(object sender, MouseButtonEventArgs e) {
        MyCanvasComponent.Children.Clear(); //removes previously drawed objects
		
		double x = e.GetPosition(MyCanvasComponent).X; //get mouse coordinates over canvas
		double y = e.GetPosition(MyCanvasComponent).Y;
        Ellipse elipsa = new Ellipse(); //create ellipse
		elipsa.StrokeThickness = 3;
		elipsa.Stroke = Brushes.Red;
		elipsa.Margin = new Thickness(x, y, 0, 0);		
		elipsa.Width = 20;
		elipsa.Height = 20;
		//add (draw) ellipse to canvas	
		MyCanvasComponent.Children.Add(elipsa);
	}
