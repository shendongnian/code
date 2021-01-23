    public partial class PropertyGridEditor : ITypeEditor
    {
    	public PropertyGridEditor()
    	{
    		InitializeComponent();
    	}
    
    	public FrameworkElement ResolveEditor(PropertyItem propertyItem)
    	{
    		if (propertyItem.Value != null)
    		{
    			var objects = propertyItem.Value;
    			foreach (var o in (IEnumerable)objects)
    			{
    				var propertyGrid = new Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid
    				{
    					IsCategorized = false,
    					IsMiscCategoryLabelHidden = true,
    					ShowAdvancedOptions = false,
    					ShowDescriptionByTooltip = true,
    					ShowPreview = false,
    					ShowSearchBox = false,
    					ShowSortOptions = false,
    					ShowTitle = true,
    					ShowSummary = false,
    					SelectedObject = o,
    				};
    				Container.Children.Add(propertyGrid);
    			}
    		}
    
    		return this;
    	}
    }
