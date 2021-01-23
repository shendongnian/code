    <Style TargetType="{x:Type TextBlock}" x:Key="WrappingStyle">
        <Setter Property="TextWrapping" Value="WrapWithOverflow"/>
    </Style>
    <Style TargetType="ContentPresenter" x:Key="ErrorListStyle">
        <Setter Property="TextBlock.Foreground" Value="{DynamicResource TextBoxBorderErrorColor}"/>
        <Setter Property="ContentTemplate">
            <Setter.Value>
                <DataTemplate>
                    <Border Margin="0,5">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="20" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Path Grid.Column="0" Fill="{DynamicResource TextBoxBorderErrorColor}" VerticalAlignment="Top" HorizontalAlignment="Left">
                                <Path.Data>
                                    <EllipseGeometry RadiusX="2.5" RadiusY="2.5"/>
                                </Path.Data>
                            </Path>
                            <ContentPresenter Grid.Column="1" Content="{Binding}" VerticalAlignment="Top">
                                <ContentPresenter.Resources>
                                    <Style TargetType="{x:Type TextBlock}" BasedOn="{StaticResource WrappingStyle}"/>
                                </ContentPresenter.Resources>
                            </ContentPresenter>
                            </Grid>
                    </Border>
                </DataTemplate>
            </Setter.Value>
        </Setter>
    </Style>
