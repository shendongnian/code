	private void Button_Click(object sender, RoutedEventArgs e)
	{
		BeatReset= true;
		CompositionTarget.Rendering += Rendering;
	}
	
	private void Rendering(object sender, EventArgs e){
		BeatReset = false;
		CompositionTarget.Rendering -= Rendering;
	}
	
