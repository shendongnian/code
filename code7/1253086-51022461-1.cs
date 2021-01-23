    <Window.Resources>
    	<ContextMenu x:Key="headerMenu">
    		<ContextMenu.Items>
    			<MenuItem
    				Header="Show/Hide Columns"
    				ItemsSource="{Binding Columns, RelativeSource={RelativeSource AncestorType=DataGrid}}">
    				<MenuItem.ItemTemplate>
    					<DataTemplate>
    						<TextBlock Text="{Binding Header}"/>
    					</DataTemplate>
    				</MenuItem.ItemTemplate>
    			</MenuItem>
    		</ContextMenu.Items>
    	</ContextMenu>
    
    	<Style TargetType="{x:Type DataGrid}">
    		<Setter Property="ContextMenu" Value="{StaticResource headerMenu}" />
    	</Style>
    </Window.Resources>
    <Grid>
    	<DataGrid x:Name="AllLogs">
    		<DataGrid.Columns>
    			<DataGridTextColumn Header="ID"></DataGridTextColumn>
    			<DataGridTextColumn Header="Name"></DataGridTextColumn>
    		</DataGrid.Columns>
    	</DataGrid>
    </Grid>
