    <Window.Resources>
        <local:MultiConverter x:Key="multiConv"/>
    </Window.Resources>
    ...
        <DataGrid ItemsSource="{Binding ViewModel.MyList}" >
            <DataGrid.RowStyle >
                <Style TargetType="{x:Type DataGridRow}">
                    <Style.Triggers>
                        <DataTrigger Value="true">
                            <DataTrigger.Binding>
                                <MultiBinding Converter="{StaticResource multiConv}">
                                    <Binding Path="ColorColumn" />
                                    <Binding Path="ViewModel.SelectedColor" RelativeSource="{RelativeSource Mode=FindAncestor,
                                                    AncestorType=Window}"/>
                                </MultiBinding>
                            </DataTrigger.Binding>
                            <Setter Property="BorderBrush" Value="Red" />
                            <Setter Property="BorderThickness" Value="1" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.RowStyle>
        </DataGrid>
        <ComboBox ItemsSource="{Binding ViewModel.ColorList}" 
                  SelectedItem="{Binding ViewModel.SelectedColor}"/>
