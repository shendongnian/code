    <Grid>
        <StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="Amount Left:" />
                <TextBlock Text="{Binding CurrentAmount}" />
            </StackPanel>
            <ListBox ItemsSource="{Binding Buttons}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Button Command="{Binding SubtractCommand}" Width="200" Height="75" x:Name="SubButtom" Content="{Binding SubtractAmount}"  IsEnabled="{Binding IsEnabled}"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </StackPanel>
    </Grid>
