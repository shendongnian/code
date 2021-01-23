    <TabControl ItemsSource="{Binding Objects}">
        <TabControl.Resources>
    		<Style TargetType="TabItem" x:Key="{x:Type TabItem}">
    			<Setter Property="Header" Value="{Binding Header}"></Setter>
    			<Style.Triggers>
    				<Trigger Property="IsVisible" Value="True">
    					<Setter Property="Content" Value="{Binding Text}"/>
    				</Trigger>
    			</Style.Triggers>
    		</Style>
    	</TabControl.Resources>
    </TabControl>
