    public class SelectedItemMessage : MvxMessage
    {
    	public SelectedItemMessage(object sender, SelectedItem selectedItem) : base(sender)
    	{
    		SelectedItem = selectedItem;
    	}
    	
    	public SelectedItem SelectedItem { get; set; }
    }
