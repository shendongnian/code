    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    public class FocusGridOnSelectionChanged : Behavior<DataGrid>
    {
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
    	}
    
    	private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    	{
    		AssociatedObject?.Focus();
    	}
    
    	protected override void OnDetaching()
    	{
    		AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
    
    		base.OnDetaching();
    	}
    
    }
	
    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
    <DataGrid ... >
    
    	<i:Interaction.Behaviors>
    		<yourbehaviorsns:FocusGridOnSelectionChanged/>
    	</i:Interaction.Behaviors>
    	
    	...
    	
    </DataGrid>
