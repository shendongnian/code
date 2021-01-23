    <DataGrid ItemsSource="{Binding Lines}" AutoGenerateColumns="False" >
        <DataGrid.Resources>
            <local:BindingProxy x:Key="proxy" Data="{Binding}"/>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="ProductId1" Binding="{Binding Path=Result[0]}" Width="{Binding Data.Columns[0].Width, Source={StaticResource proxy}, Mode=TwoWay}" />
            <DataGridTextColumn Header="ProductId2" Binding="{Binding Path=Result[1]}" Width="{Binding Data.Columns[1].Width, Source={StaticResource proxy}, Mode=TwoWay}"/>
        </DataGrid.Columns>
    </DataGrid>
