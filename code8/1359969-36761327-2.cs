    <Window.DataContext>
        <local:ApplicationVm />
    </Window.DataContext>
    <StackPanel>
        <!-- Game view placeholder -->
        <ContentControl Content="{Binding Game}">
            <ContentControl.ContentTemplate>
                <DataTemplate DataType="{x:Type local:GameVm}">
                    <StackPanel>
                        <TextBlock Text="{Binding Health}"/>
                        <TextBlock Text="{Binding Armor}"/>
                    </StackPanel>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
        <!-- Game controls pane -->
        <Button Content="Restart game" Command="{Binding RestartGameCommand}"/>
    </StackPanel>
