    public class ControlVM
    {
        public int X {get;set;}
        public int Y {get;set;}
    }
    <ItemsControl ItemsSource="{Binding Rectangles}" >
        ... specify Canvas as the items panel ...
        <ItemsControl.ItemContainerStyle>
            <Style>
                <Setter Property="Canvas.Left" Value="{Binding X}" />
                <Setter Property="Canvas.Top" Value="{Binding Y}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
