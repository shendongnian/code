       public class CustomViewCell : ViewCell
    		{
                public CustomViewCell()
    			{
                    //instantiate each element we want to use.
                    var image = new CircleCachedImage
                    {
                        Margin = new Thickness(20, 10, 0, 10),
                        WidthRequest = App.ScreenWidth * 0.15,
                        HeightRequest = App.ScreenWidth * 0.15,
                        Aspect = Aspect.AspectFill,
                        BorderColor = Color.FromHex(App.PrimaryColor),
                        BorderThickness = 2,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    var nameLabel = new Label
                    {
                        Margin = new Thickness(20, 15, 0, 0),
                        FontFamily = "Lato",
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 17
                    };
                    var locationLabel = new Label
                    {
                        Margin = new Thickness(20, 0, 0, 5),
                        FontFamily = "Lato",
                        FontSize = 13
                    };
    				//Create layout
                    var verticaLayout = new StackLayout();
                    var horizontalLayout = new StackLayout() { BackgroundColor = Color.White };
    
    				//set bindings
    				nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
    				locationLabel.SetBinding(Label.TextProperty, new Binding("Location"));
                    image.SetBinding(CircleCachedImage.SourceProperty, new Binding("Image"));
    
    				//Set properties for desired design
    				horizontalLayout.Orientation = StackOrientation.Horizontal;
    				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
    				image.HorizontalOptions = LayoutOptions.End;
    
    
    				//add views to the view hierarchy
                    horizontalLayout.Children.Add(image);
    				verticaLayout.Children.Add(nameLabel);
    				verticaLayout.Children.Add(locationLabel);
    				horizontalLayout.Children.Add(verticaLayout);
    				//HERE IS THE MOST IMPORTANT PART
                    var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
                    
    
                    deleteAction.Clicked += async (sender, e) => {
                        //Here do your deleting / calling to WebAPIs
                        //Now remove the item from the list. You can do this by sending an event using messaging center looks like: 
                        //MessagingCenter.Send<TSender,string>(TSender sender, string message, string indexOfItemInListview)
                    };
                    // add to the ViewCell's ContextActions property
                    ContextActions.Add(deleteAction);
    
    				// add to parent view
    				View = horizontalLayout;
    			}
    		}
