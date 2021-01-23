    <Grid.Resources>
        <Style TargetType="{x:Type DataGridCell}" x:Key="BuyTemplate">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridCell}">
                        <CheckBox HorizontalAlignment="Center" IsChecked="{Binding Buy, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style TargetType="{x:Type DataGridCell}" x:Key="RentTemplate">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridCell}">
                        <CheckBox HorizontalAlignment="Center" IsChecked="{Binding Rent, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <DataTemplate x:Key="BuyButtonTemplate">
            <Button HorizontalAlignment="Center" IsEnabled="{Binding Buy}" Content="BUY NOW!" />
        </DataTemplate>
        <DataTemplate x:Key="RentButtonTemplate">
            <Button HorizontalAlignment="Center" IsEnabled="{Binding Rent}" Content="Rent this car!" />
        </DataTemplate>
    </Grid.Resources>
    <DataGrid Name="CarGrid" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
            <DataGridCheckBoxColumn Header="IsBuy" Width="75" CellStyle="{StaticResource ResourceKey=BuyTemplate}" />
            <DataGridCheckBoxColumn Header="IsRent" Width="75"  CellStyle="{StaticResource ResourceKey=RentTemplate}" />
            <DataGridTemplateColumn Header="Buy" CellTemplate="{StaticResource ResourceKey=BuyButtonTemplate}" />
            <DataGridTemplateColumn Header="Rent" CellTemplate="{StaticResource ResourceKey=RentButtonTemplate}" />
        </DataGrid.Columns>
    </DataGrid>
