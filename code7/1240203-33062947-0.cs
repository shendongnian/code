    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <RadioButton Margin="2,3.5"
                         Content="{Binding Path=DescriptionPrice}"
                         GroupName="ServiceType"
                         IsChecked="{Binding Path=IsSelected}">
                <RadioButton.Triggers>
                    <EventTrigger RoutedEvent="ToggleButton.Checked">
                    </EventTrigger>
                </RadioButton.Triggers>
            </RadioButton>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
