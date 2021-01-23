    <Window.Resource>
        <DataTemplate x:Key="FirstTemplate">
			<TextBlock Style="{StaticResource DataGridTextBlockStyle}" 
					   Text="{Binding Module.DisplayItem.Text}"/>
        </DataTemplate>
		<DataTemplate x:Key="SecondTemplate">
			<TextBlock Style="{StaticResource DataGridTextBlockStyle}" 
					   Text="{Binding Module.GeneralItem.DisplayItem.Text}"/>
        </DataTemplate>
    </Window.Resource>
	<DataGridTemplateColumn Header="Item-Name">
		<DataGridTemplateColumn.CellTemplateSelector>
			<local:DisplayItemTemplateSelector
				FirstTemplate="{StaticResource FirstTemplate}"
				SecondTemplate="{StaticResource SecondTemplate}"/>
		</DataGridTemplateColumn.CellTemplateSelector>
	</DataGridTemplateColumn>
	
	public class DisplayItemTemplateSelector : DataTemplateSelector
	{
	  public DataTemplate FirstTemplate
	  { get; set; }
		
	  public DataTemplate SecondTemplate
	  { get; set; }
		
	  public override DataTemplate SelectTemplate(object item, DependencyObject container)
	  {
		if (item is  GeneralItem)
		{
			//second template etc
		}
		else if (item is DisplayItem)
		{
			//first template
		}
		else
		  return base.SelectTemplate(item, container);
	  }
	}
