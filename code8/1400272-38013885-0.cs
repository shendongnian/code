    <DataGrid ItemsSource="{Binding Path=SelectedItem.Sammelakte.SammelakteAkten, ElementName=sammelaktenDataGrid}">
        <DataGrid.Style>
            <Style TargetType="DataGrid">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path= SelectedItem.Sammelakte.SammelakteAkten}" Value="{x:Null}">
                        <Setter Property="ItemsSource" Value="{Binding Path=AngemeldeterBenutzer.AktenBenutzer}" />
                    </DataTrigger>                                     
                </Style.Triggers>
            </Style>
        </DataGrid.Style>            
    </DataGrid>
