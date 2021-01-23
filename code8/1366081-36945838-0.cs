        public class ProfilePageTemplateSelector : DataTemplateSelector
    	{
    		public DataTemplate dtPostTemplate { get; set; }
    		public DataTemplate dtCommentTemplate { get; set; }
    
    		protected override DataTemplate SelectTemplateCore( object item, DependencyObject container )
    		{
    			var uiElement = container as UIElement;
    			if ( uiElement == null )
    			{
    				return base.SelectTemplate( item, container );
    			}
    
     			if ( item is Post )
     			{
    				return dtPostTemplate;
     			}
     			else if ( item is Comment )
     			{
    				return dtCommentTemplate;
     			}
    			return base.SelectTemplateCore( item, container );
    		}
    	
