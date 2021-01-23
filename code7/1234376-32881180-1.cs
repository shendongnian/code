    public class BindModel
    {
        public Windows.UI.Color Color { get; set; }
    }
    <DataTemplate x:Key="test" x:DataType="local:BindModel">
        <TextBlock>
            <TextBlock.Foreground>
                <SolidColorBrush Color="{x:Bind Color}"></SolidColorBrush>
            </TextBlock.Foreground>
        </TextBlock>
    </DataTemplate>
