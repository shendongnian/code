    <DataGrid x:Name="MyDataGrid"   ItemsSource="{Binding Path=MyObservableCollection}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="ServerName" Binding="{Binding servername}"/>
                    <DataGridTextColumn Header="MapName" Binding="{Binding mapname}"/>
                    <DataGridTextColumn Header="MaxPlayers" Binding="{Binding servermaxplayer}"/>               
                </DataGrid.Columns>
    </DataGrid>
