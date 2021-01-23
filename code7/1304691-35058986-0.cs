        <Grid Grid.Row="1" Height="Auto">
            <Grid.Background>
                <LinearGradientBrush>
                    <LinearGradientBrush.GradientStops>
                        <GradientStop Color="#252525" />
                    </LinearGradientBrush.GradientStops>
                </LinearGradientBrush>
            </Grid.Background>
            <ListBox Name="ModelsListBox" Background="Transparent" Foreground="AntiqueWhite" BorderBrush="Transparent" ScrollViewer.HorizontalScrollBarVisibility="Disabled"
                     HorizontalContentAlignment="Stretch" ItemsSource="{Binding Source={x:Static Context:Session.CurrentSession}, Path=CurrentProject.Models}">
                <ListBox.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="Delete" Command="{Binding DeleteModel3DCommand}" CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=ContextMenu}, Path=PlacementTarget.SelectedItem}"/>
                        <MenuItem Header="Rename"/>
                    </ContextMenu>
                </ListBox.ContextMenu>
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="SelectionChanged">
                        <i:InvokeCommandAction Command="{Binding SelectModel3DCommand}" CommandParameter="{Binding Path=SelectedItem, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListBox}}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Grid Margin="0,0,5,0" HorizontalAlignment="Left">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto" />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>
                            <Image Source="/McKineap;component/Resources/Images/logo-mckineap.png"  Grid.Column="0" HorizontalAlignment="Left" VerticalAlignment="Bottom" Height="55" Width="50"/>
                            <ListBoxItem Grid.Column="1" Content="{Binding NameWithoutExtension}" HorizontalAlignment="Stretch" />
                        </Grid>
                    </DataTemplate>
                </ListBox.ItemTemplate>
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel/>
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
            </ListBox>
        </Grid>
