                  <RibbonMenuButton LargeImageSource="Images/DeleteUser1.png" Label="Delete" ItemsSource="{Binding AvailibleUsers}">
                        <RibbonGallery Command="{Binding CommandDeleteAllPermissions}">
                            <RibbonGalleryCategory ItemsSource="{Binding AvailibleUsers}" Header="User List">
                                <RibbonGalleryCategory.ItemTemplate>
                                    <DataTemplate>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="Auto" />
                                                <ColumnDefinition Width="*" />
                                            </Grid.ColumnDefinitions>
                                            <Image Source="Images/DeleteUser1.png" Width="25"/>
                                            <ContentPresenter Content="{Binding}" Grid.Column="1"/>
                                        </Grid>
                                    </DataTemplate>
                                </RibbonGalleryCategory.ItemTemplate>
                            </RibbonGalleryCategory>
                        </RibbonGallery>
                    </RibbonMenuButton>
