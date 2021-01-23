    <Grid>
        <Grid.Resources>
            <l:ViewModel x:Key="viewModel" />
            <l:ImageLocationConverter x:Key="ImageLocationConverter" />
            <Style TargetType="ContentPresenter">
                <Setter Property="Canvas.Left">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource ImageLocationConverter}">
                            <Binding Path="Left" />
                            <Binding Path="ActualWidth"
                                     RelativeSource="{RelativeSource FindAncestor,AncestorType=Canvas}" />
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
                <Setter Property="Canvas.Top">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource ImageLocationConverter}">
                            <Binding Path="Top" />
                            <Binding Path="ActualHeight"
                                     RelativeSource="{RelativeSource FindAncestor,AncestorType=Canvas}" />
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <ItemsControl ItemsSource="{Binding Images,Source={StaticResource viewModel}}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Canvas />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Border BorderBrush="White"
                                BorderThickness="5">
                            <Image Source="{Binding Image}"
                                   Width="{Binding Width}"
                                   Height="{Binding Height}"
                                   Stretch="UniformToFill">
                            </Image>
                            <Border.RenderTransform>
                                <RotateTransform Angle="{Binding Angle}" />
                            </Border.RenderTransform>
                        </Border>
                        <Grid.Effect>
                            <DropShadowEffect Opacity=".5"
                                              BlurRadius="10" />
                        </Grid.Effect>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
