    <TabControl ItemsSource="{Binding Objects}">
    	<TabControl.ItemTemplate>
    		<DataTemplate>
    			<TabItem>
    				<ContentControl>
    					<ContentControl.Style>
    						<Style TargetType="ContentControl">
    							<Style.Triggers>
    								<Trigger Property="IsVisible" Value="True">
    									<Setter Property="Content" Value="{Binding Text}"/>
    								</Trigger>
    							</Style.Triggers>
    						</Style>
    					</ContentControl.Style>
    				</ContentControl>
    			</TabItem>
    		</DataTemplate>
    	</TabControl.ItemTemplate>
    </TabControl>
