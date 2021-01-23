    void navigatePage_onSelected(object sender, SelectedItemChangedEventArgs args){
    			_menulink menuitem = (_menulink)args.SelectedItem;
    			MasterDetailPage mstr = (MasterDetailPage)(Application.Current.MainPage); // My Application main page is a Masterpage so..
    			if (menuitem._link == "ABOUT FTW") {
    				mstr.Detail = new NavigationPage (new AboutFTW ());
    			}else if(menuitem._link == "I NEED HELP"){
    				mstr.Detail = new NavigationPage (new Entertainment ());
    			}else if(menuitem._link == "HOME"){
    				mstr.Detail = new NavigationPage (new FTWHome ());
    			}
    			// Show the detail page.
    			mstr.IsPresented = false;
    		}
