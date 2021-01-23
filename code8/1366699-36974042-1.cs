    PopupPage popUp; //This will be the layout of the form
    
    Page : ContentPage {
    	
    	var gird = new Gird();
    
    	popUp = PopupPage();
    	popUp.IsVisible = false;
    
    	var mainContainer = new StackLayout();
    
    	mainContainer.Children.Add(All you UI stuff..);
    
    	var btn = new Button();
    	btn.Clicked += OnButtonClicked;
    
    	grid.Children.Add(mainContainer,0,0);
    	grid.Children.Add(popUp,0,0);
    
    }
    
