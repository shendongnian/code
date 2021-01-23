    <StackPanel>
        <StackPanel.Resources>
            <CollectionViewSource x:Key="cvs" Source="{Binding FilteredPhotoFiles}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="DateTaken"/>
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </StackPanel.Resources>
        <ListView ItemsSource="{Binding Source={StaticResource cvs}}" SelectedItem="{Binding SelectedPhotoVM.SelectedPhoto}">
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel Width="{Binding (FrameworkElement.ActualWidth), RelativeSource={RelativeSource AncestorType={x:Type ScrollContentPresenter}}}"
                        ItemWidth="{Binding (ListView.View).ItemWidth, RelativeSource={RelativeSource AncestorType={x:Type ListView}}}"
                        MinWidth="{Binding ItemWidth, RelativeSource={RelativeSource Self}}"
                        ItemHeight="{Binding (ListView.View).ItemHeight, RelativeSource={RelativeSource AncestorType={x:Type ListView}}}"/>
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="2,4,2,4">
                        <Grid.Background>
                            <SolidColorBrush Color="LightGray" Opacity="0.5"/>
                        </Grid.Background>
                        <Image Source="{Binding PhotoFileInfo.FullName}" Width="300" Height="170" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.GroupStyle>
                <GroupStyle>
                    <GroupStyle.HeaderTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Name}"/>
                        </DataTemplate>
                    </GroupStyle.HeaderTemplate>
                </GroupStyle>
            </ListView.GroupStyle>
        </ListView>
    </StackPanel>
