    <Page.BottomAppBar >
        <CommandBar x:Name="commandBar" DataContext="{Binding}">
            <CommandBar.Content>
                <StackPanel Margin="0,0">
                    <ListView ItemsSource="{Binding Confirmation.AvailableValues}" ItemContainerStyle="{StaticResource ListViewItemBase}">
                        <ListView.ItemTemplate>
                            <DataTemplate>
                                <Button Content="{Binding Value.DisplayName}" Command="{Binding DataContext.Confirm, ElementName=commandBar}" CommandParameter="{Binding Value}" HorizontalAlignment="Center"></Button>
                            </DataTemplate>
                        </ListView.ItemTemplate>
                    </ListView>
                    <Line Margin="5" X1="0" X2="1000" Y1="0" Y2="0" HorizontalAlignment="Stretch" Height="2"  Stroke="#888888"   StrokeThickness="1" ></Line>
                </StackPanel>
            </CommandBar.Content>
        </CommandBar>
    </Page.BottomAppBar>
