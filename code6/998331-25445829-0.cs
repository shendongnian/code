    <ItemsControl ItemsSource="{Binding Path=Substances}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                 <Button Style="{StaticResource SomeStyleToChangeItsLook}"
                         Command="{Binding Path=SelectSubstanceCommand}"
                         CommandParameter="{Binding}"
                         Content="{Binding Path=Name}" />
           </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
    public ICommand SelectSubstanceCommand { get; private set; }
    private void SelectSubstance(object parameter)
    {
        // Add the substance that was "clicked" on here however you want to do it.
    }
