    public class FocusTriggerAction : TriggerAction<SearchBar>
    {
    	public bool Focused { get; set; }
    
        protected override void Invoke (SearchBar searchBar)
        {
            if (Focused)
            {
            	searchBar.Focus();
            }
            else
            {
            	searchBar.UnFocus();
            }
        }
    }
