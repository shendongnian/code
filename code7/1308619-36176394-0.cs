    <DataTemplate DataType="WpfApplication1:Model">
        <ComboBox ItemsSource="{Binding Items}"
                SelectedItem="{Binding SelectedItem}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Description}"></TextBlock>
                </DataTemplate>
            </ComboBox.ItemTemplate>
            <ComboBox.Resources>
                <VisualBrush x:Key="_myBrush">
                    <VisualBrush.Visual>
                        <TextBlock Text="{Binding Name}"/>
                    </VisualBrush.Visual>
                </VisualBrush>
            </ComboBox.Resources>
            <ComboBox.Style>
                <Style TargetType="ComboBox">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem}" Value="{x:Null}">
                            <Setter Property="Background" Value="{StaticResource _myBrush}"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ComboBox.Style>
        </ComboBox>
    </DataTemplate>
