        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			try{
				    this.ViewControllerSelected += (object sender, UITabBarSelectionEventArgs e) => {
					switch(TabBar.SelectedItem.Title)
					{
					case"TAB 1" :
						Title = "TAB 1";
						break;
					case "TAB 2":	
                      Title = "TAB 2";
						break;
					default:
						Title = "TAB 3";
						break;
					}
				};
			}catch(Exception e)
			{
				Console.WriteLine (e.Message);
			}
		}
  
