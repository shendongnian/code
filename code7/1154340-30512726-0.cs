            <ListBox
                Name="lbxUninspectedPrints"
                Height="125"
                Margin="16,0"
                Background="{StaticResource primaryBrush}"
                Foreground="White"
                VerticalAlignment="Top"
                VerticalContentAlignment="Top"
                HorizontalContentAlignment="Left"
                ScrollViewer.CanContentScroll="True"
                ScrollViewer.VerticalScrollBarVisibility="Hidden"
                ScrollViewer.HorizontalScrollBarVisibility="Disabled"
                ItemsSource="{Binding UninspectedPrintList}">
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel/>
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Button
                            DataContext="{Binding}"
                            Width="44"
                            Height="24"
                            VerticalAlignment="Top"
                            VerticalContentAlignment="Center"
                            HorizontalAlignment="Left"
                            HorizontalContentAlignment="Center"
                            Content="{Binding}"
                            Command="{
                                Binding DataContext.DiePrintNav.UninspectedPrintSelectedCommand,
                                RelativeSource={RelativeSource AncestorType=ListBox}}"
                            CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=Content}">
                            <Button.Template>
                                <ControlTemplate TargetType="Button">
                                    <Border
                                        BorderBrush="White"
                                        BorderThickness="2"
                                        Background="Transparent">
                                        <Border.Triggers>
                                            <EventTrigger RoutedEvent="Border.MouseEnter">
                                                <EventTrigger.Actions>
                                                    <BeginStoryboard>
                                                        <Storyboard>
                                                            <ColorAnimation
                                                                Storyboard.TargetProperty="
                                                                    (Border.Background).
                                                                    (SolidColorBrush.Color)"
                                                                From="Transparent"
                                                                To="{StaticResource accentColorTwo}"
                                                                Duration="0:0:0.25"/>
                                                        </Storyboard>
                                                    </BeginStoryboard>
                                                </EventTrigger.Actions>
                                            </EventTrigger>
                                            <EventTrigger RoutedEvent="Border.MouseLeave">
                                                <EventTrigger.Actions>
                                                    <BeginStoryboard>
                                                        <Storyboard>
                                                            <ColorAnimation
                                                                Storyboard.TargetProperty="
                                                                    (Border.Background).
                                                                    (SolidColorBrush.Color)"
                                                                From="{StaticResource accentColorTwo}"
                                                                To="Transparent"
                                                                Duration="0:0:0.25"/>
                                                        </Storyboard>
                                                    </BeginStoryboard>
                                                </EventTrigger.Actions>
                                            </EventTrigger>
                                        </Border.Triggers>
                                        <ContentPresenter
                                            TextBlock.TextAlignment="Center"
                                            TextBlock.Foreground="White"
                                            TextBlock.FontFamily="SegoeUI"
                                            TextBlock.FontSize="14"
                                            Content="{TemplateBinding Content}"/>
                                    </Border>
                                </ControlTemplate>
                            </Button.Template>
                        </Button>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
