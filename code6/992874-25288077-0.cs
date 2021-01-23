    <ListBox x:Name="listBox" ItemsSource="{Binding PersonCollection}" SelectedItem="{Binding SelectedPerson}">
      <ListBox.ItemTemplate>
        <DataTemplate>
          <Grid>
            <i:Interaction.Behaviors>
              <catel:DoubleClickToCommand Command="{Binding ElementName=listBox, Path=DataContext.Edit}" />
            </i:Interaction.Behaviors>
     
            <StackPanel Orientation="Horizontal">
              <Label Content="{Binding FirstName}" />
              <Label Content="{Binding MiddleName}" />
              <Label Content="{Binding LastName}" />
            </StackPanel>
          </Grid>
        </DataTemplate>
      </ListBox.ItemTemplate>
    </ListBox>
