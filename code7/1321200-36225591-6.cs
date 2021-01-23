    [assembly: ExportRenderer (typeof(ListView), typeof(NoRippleListViewRenderer))]
    namespace Your.Own.Namespace
    {
    	public class NoRippleListViewRenderer : ListViewRenderer
    	{
    		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
    		{
    			base.OnElementChanged (e);
    			Control.SetSelector (Resource.Layout.no_selector);
    		}
    	}
    }
