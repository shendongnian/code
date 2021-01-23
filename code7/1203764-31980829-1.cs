    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <!-- This one chooses the view -->
        <CheckBox x:Name="ViewSelector" Content="View shapes"/>
        
        <TabControl Grid.Row="1" ItemsSource="{Binding}">
            <TabControl.Resources>
                <DataTemplate x:Key="TextualTemplateKey">
                    <StackPanel>
                        <TextBlock Text="{Binding X}"/>
                        <TextBlock Text="{Binding Y}"/>
                    </StackPanel>
                </DataTemplate>
                <DataTemplate x:Key="ShapesTemplateKey">
                    <Rectangle Fill="Green" Width="{Binding X}" Height="{Binding Y}"/>
                </DataTemplate>
            </TabControl.Resources>
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"/>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ItemContainerStyle>
                <Style TargetType="{x:Type TabItem}">
                    <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                    <Setter Property="ContentTemplate" Value="{StaticResource TextualTemplateKey}"/>
                    <Style.Triggers>
                        <!-- When "View shapes" is checked, we're changing data template to a new one -->
                        <DataTrigger Binding="{Binding IsChecked, ElementName=ViewSelector}" Value="True">
                            <Setter Property="ContentTemplate" Value="{StaticResource ShapesTemplateKey}"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TabControl.ItemContainerStyle>
        </TabControl>
    </Grid>
