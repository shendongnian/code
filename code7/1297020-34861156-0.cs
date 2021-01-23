        <DataGrid Name="gridEmployees" ItemsSource="{Binding Employees}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <local:CustomCommandAction Command="{Binding DoubleClickCommand}" CommandParameter="{Binding ElementName=gridEmployees, Path=SelectedItems[0]}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </DataGrid>
