    <DataTemplate DataType="{x:Type viewModel:ActionItem}">
    
        <Button Background="SlateGray" Command="{Binding Command}">
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Setter Property="Background" Value="Green"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type Button}">
                                <Border Background="{TemplateBinding Background}">
                                    <ContentPresenter />
                                </Border>
    
                     <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="DarkGoldenrod"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    
                </Style>
            </Button.Style>
    
            <TextBlock Text="{Binding Name}" />
    
        </Button>
    
    </DataTemplate>
