    <toolkit:ListPicker x:name="picker" ItemsSource="{Binding Sentences}">
     <i:Interaction.Triggers>
        <i:EventTrigger EventName="SelectionChanged">
            <command:EventToCommand Command="{Binding PickerCommand, Mode=OneWay}" />
        </i:EventTrigger>
    </i:Interaction.Triggers>
            <toolkit:ListPicker.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding }"/>
                </DataTemplate>
            </toolkit:ListPicker.ItemTemplate>
