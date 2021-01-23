    <ListBox ItemsSource="{Binding CityList}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock x:name="Name" Text="{Binding Name }" >
    				   <i:Interaction.Triggers>
                            <i:EventTrigger EventName="Tap">
                                <command:EventToCommand Command="{Binding NameSelectedCommand, Mode=OneWay}" CommandParameter="{Binding Path=SelectedItem, ElementName=CityList}" PassEventArgsToCommand="False"/>
                            </i:EventTrigger>
                       </i:Interaction.Triggers>
    				</TextBlock>
                    <TextBlock x:name="Country" Text="{Binding  Country}" >
    				   <i:Interaction.Triggers>
                            <i:EventTrigger EventName="Tap">
                                <command:EventToCommand Command="{Binding CountrySelectedCommand, Mode=OneWay}" CommandParameter="{Binding Path=SelectedItem, ElementName=CityList}" PassEventArgsToCommand="False"/>
                            </i:EventTrigger>
    				   </i:Interaction.Triggers>
    				</TextBlock>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
