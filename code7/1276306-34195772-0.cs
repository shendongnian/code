    <GroupBox Header="NewsBox">
    	<GroupBox.Style>
    		<Style TargetType="GroupBox">
    			<Style.Triggers>
    				<DataTrigger Binding="{Binding  ElementName=TabControl, Path=SelectedIndex}" Value="0">
    					<Setter Property="Content">
    						<Setter.Value>
    							<NewsDay:NewsDayControl DataContext="{Binding SelectedNews}"/>
    						</Setter.Value>
    					</Setter>
    				</DataTrigger>
    				<DataTrigger Binding="{Binding  ElementName=TabControl, Path=SelectedIndex}" Value="1">
    					<Setter Property="Content">
    						<Setter.Value>
    							<Imprint:ImprintControl DataContext="{Binding SelectedImprint}"/>
    						</Setter.Value>
    					</Setter>
    				</DataTrigger>
    			</Style.Triggers>
    		</Style>
    	</GroupBox.Style>
    </GroupBox>
