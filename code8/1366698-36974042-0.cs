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
    
    So in order to show the popoUP you need to play with the IsVisible property, for example:
    
    void OnButtonClicked(){
    	
    	//You can center the popup using Vertical options or whatever you need
    	//and to resize the pop up you can do different calculations like
    	//popUp.Width = ScreenWidth / 2 and popUp.Height = ScreenWidth / 2
    	popUp.IsVisile = true;
    
    }
