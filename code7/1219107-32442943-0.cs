    <ListBox Name="lbEurInsuredType" HorizontalContentAlignment="Stretch" ItemsSource="{Binding}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid Margin="0,2">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="80"></ColumnDefinition>
                        <ColumnDefinition Width="30"></ColumnDefinition>
                        <ColumnDefinition Width="20"></ColumnDefinition>
                   </Grid.ColumnDefinitions>
                   <TextBlock Text="{Binding Title}"></TextBlock>
                   <TextBox Text="{Binding Uw}" Grid.Column="1"></TextBox>
                   <TextBox Text="{Binding Partner}" Grid.Column="2"></TextBox>
               </Grid>
           </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
