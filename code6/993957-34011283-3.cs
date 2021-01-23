    <DataGrid local:DataGridTextSearch.SearchValue="{Binding ElementName=txtSearch, Path=Text, UpdateSourceTrigger=PropertyChanged}">
    <DataGrid.Resources>
    <local:SearchValueConverter x:Key="SearchValueConverter"/>
    <Style TargetType="{x:Type DataGridCell}">
        <Setter Property="local:DataGridTextSearch.IsTextMatch">
            <Setter.Value>
                <MultiBinding Converter="{StaticResource SearchValueConverter}">
                    <Binding RelativeSource="{RelativeSource Self}" Path="Content.Text" />
                    <Binding RelativeSource="{RelativeSource Self}" Path="(local:DataGridTextSearch.SearchValue)" />
                </MultiBinding>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="local:DataGridTextSearch.IsTextMatch" Value="True">
                <Setter Property="Background" Value="Orange" />
                <Setter Property="Tag" Value="1" />
            </Trigger>
        </Style.Triggers>
    </Style>
    </DataGrid.Resources>
    </DataGrid>
  
