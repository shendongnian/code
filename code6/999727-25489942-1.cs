    //Datacontext is MyClass object
    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding AsIEnumerable}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Parameter 2" Binding="{Binding Path=Parameter2}" />
        </DataGrid.Columns>
    </DataGrid>
