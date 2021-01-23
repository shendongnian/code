    <DataGrid AutoGenerateColumns="False" VerticalAlignment="Stretch"  Grid.Row="1" Name="dg1" ItemsSource="{Binding Source={StaticResource XmlData},XPath=Limits/*}">
    	<DataGrid.Columns>
    		<DataGridTemplateColumn Header="Capacite" CellTemplate="{StaticResource CustomCapacityTemplate}" />
    		<DataGridTemplateColumn Header="Clear" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter={x:Null}}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    		<DataGridTemplateColumn Header="Aucune" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter=Aucune}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    		<DataGridTemplateColumn Header="Legere" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter=Legere}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    		<DataGridTemplateColumn Header="Moderee" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter=Moderee}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    		<DataGridTemplateColumn Header="Forte" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter=Forte}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    		<DataGridTemplateColumn Header="Totale" Width="60">
    			<DataGridTemplateColumn.CellTemplate>
    				<DataTemplate>
    					<RadioButton GroupName="{Binding XPath=ID}" 
    						IsChecked={Binding XPath=CurrentOption, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged,
    						Converter={StaticResource CurrentOptionConverter}, ConverterParameter=Totale}" />
    				</DataTemplate>
    			</DataGridTemplateColumn.CellTemplate>
    		</DataGridTemplateColumn>
    	</DataGrid.Columns>
    
