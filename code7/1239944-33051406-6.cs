    <ItemsControl ItemsSource="{Binding Letters}" VerticalAlignment="Center">
        <ItemsControl.DataContext>
            <local:LettersViewModel/>
        </ItemsControl.DataContext>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Content="{Binding}" MinWidth="20" Click="LetterButtonClick"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
