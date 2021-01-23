    [assembly: ExportRenderer(typeof(TableView), typeof(CustomTableView))]
    namespace APP.Droid
    {
    	public class CustomTableView : TableViewRenderer
    	{
    		protected override TableViewModelRenderer GetModelRenderer(global::Android.Widget.ListView listView, TableView view)
    		{
    			return new CustomTableViewModelRenderer(this.Context, listView, view);
    		}
    
    	}
    }
