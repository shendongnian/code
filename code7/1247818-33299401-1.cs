    <ItemsControl Name="icCircles">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas Background="Transparent"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Canvas.Left" Value="{Binding X}"/>
                <Setter Property="Canvas.Top" Value="{Binding Y}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Path Fill="Black">
                    <Path.Data>
                        <EllipseGeometry RadiusX="2.5" RadiusY="2.5"/>
                    </Path.Data>
                </Path>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
