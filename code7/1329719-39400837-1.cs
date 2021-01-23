    [assembly: ExportRenderer(typeof(TableViewModelRenderer), typeof(CustomTableViewModelRenderer))]
    namespace APP.Droid
    {
    	public class CustomTableViewModelRenderer : TableViewModelRenderer
    	{
    		public CustomTableViewModelRenderer(Context Context, global::Android.Widget.ListView ListView, TableView View)
    			: base(Context, ListView, View)
    		{ }
    		public override global::Android.Views.View GetView(int position, global::Android.Views.View convertView, ViewGroup parent)
    		{
    			var view = base.GetView(position, convertView, parent);
    
    			var element = this.GetCellForPosition(position);
    
    			if (element.GetType() == typeof(TextCell))
    			{
    				try
    				{
    					var text = ((((view as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as TextView);
    					var divider = (view as LinearLayout).GetChildAt(1);
    
    					text.SetTextColor(Android.Graphics.Color.Rgb(50, 50, 50));
    					divider.SetBackgroundColor(Android.Graphics.Color.Rgb(150, 150, 150));
    				}
    				catch (Exception) { }
    			}
    
    			return view;
    		}
    	}
    }
