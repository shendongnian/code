	public App ()
	{
		// The root page of your application
		var scaleUp = new Button {
			Text = "Scale Up"
		};
		scaleUp.Clicked += (sender, e) => {
			this.MainPage.Scale += 1;
		};
		var scaleDown = new Button {
			Text = "Scale Down"
		};
		scaleDown.Clicked += (object sender, EventArgs e) => {
			this.MainPage.Scale -= 1;
		};
		MainPage = new ContentPage {
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					scaleUp,
					scaleDown
				}
			}
		};
	}
