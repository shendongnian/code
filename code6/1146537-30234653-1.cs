    <ListView ItemsSource="{Binding Items}">
        <ListView.ItemTemplate>
             <DataTemplate>
                <Grid>
                  <Grid.ColumnDefinitions>
                     <ColumnDefinition/>
                     <ColumnDefinition/>
                  </Grid.ColumnDefinitions>
                  <Label Grid.Column="0" Grid.ZIndex="1" Content="{Binding CCC}"/>
                  <Label Grid.Column="1" Grid.ZIndex="1" Content="{Binding DDD}"/>
                  <ProgressBar Grid.ColumnSpan="2" Grid.ZIndex="0" Value="{Binding ProgressBarValue}"/>
                </Grid>
             </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
