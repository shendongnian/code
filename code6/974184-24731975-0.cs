    <ItemsControl ItemsSource="{Binding MachineFunctions}">
        <ItemsControl.Resources>
            <DataTemplate DataType="{Binding YourPrefix:MachineFunction}">
                ...
            </DataTemplate>
        </ItemsControl.Resources>
    </ItemsControl>
    <Button Content="+ Add Machine Function" ... />
...
    MachineFunctions.Add(new MachineFunction());
