    class SearchDelegate : UISearchBarDelegate
    		{
    			public override void SearchButtonClicked (UISearchBar bar)
    			{
    				bar.ResignFirstResponder ();
    			}
    
    			public override void CancelButtonClicked (UISearchBar bar)
    			{
    				bar.ResignFirstResponder ();
    			}
    
    			public override bool ShouldBeginEditing (UISearchBar searchBar)
    			{
    				
    				return true;
    			}
    
    			public override bool ShouldEndEditing (UISearchBar searchBar)
    			{
    				return true;
    			}
    
    			public override bool ShouldChangeTextInRange (UISearchBar searchBar, NSRange range, string text)
    			{
    				Console.WriteLine (searchBar.Text);
    				return true;
    			}
    		}
