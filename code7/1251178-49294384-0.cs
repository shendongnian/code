                <DataGrid x:Name="ListeUrls" AutoGenerateColumns="False" Margin="1,0,-1,27" >
                    <DataGrid.Resources>
                        <Style TargetType="{x:Type DataGridCell}">
                            <EventSetter Event="MouseDoubleClick" Handler="DataGridCell_MouseDoubleClick"/>
                        </Style>
                    </DataGrid.Resources>
                    <DataGrid.Columns>
                        <DataGridTextColumn Binding="{Binding Id}" Visibility="Hidden"></DataGridTextColumn>
                        <DataGridTextColumn Header="Vendor" Binding="{Binding Vendor}" Foreground="red" FontWeight="Bold" ></DataGridTextColumn>
                        <DataGridTextColumn Header="Url" Binding="{Binding url}" ></DataGridTextColumn>
                        
                    </DataGrid.Columns>
                </DataGrid>
