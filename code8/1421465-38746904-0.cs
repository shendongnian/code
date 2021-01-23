    <Button Grid.Row="1" Grid.Column="0"
        CommandParameter="{Binding ElementName=workGridView}"
        Command="{Binding addWorkCommand}" >
     ....
 
    private void addWork(object o)
    {
        RadGridView grid = o as RadGridView;
        grid.BeginInsert();
    }
