            <ComboBox.ItemTemplate>
                <DataTemplate DataType="local:ComboBoxItemString">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Number, StringFormat='000 - '}" />
                        <TextBlock Text="{Binding ValueString}" />
                    </StackPanel>
                </DataTemplate>
    //add Number property to you class
    public class ComboBoxItemString
    {
        public string ValueString { get; set; }
        public int Number { get; set; }
    }
    //add the array
    <x:Array x:Key="SongTitleString" Type="local:ComboBoxItemString">
        <local:ComboBoxItemString ValueString = "Song 1" Number = "1" />
        <local:ComboBoxItemString ValueString = "Song 2" Number = "2" />
        <local:ComboBoxItemString ValueString = "Song 3" Number = "3" />
    </x:Array>
