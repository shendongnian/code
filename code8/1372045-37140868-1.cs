    <ResourceDictionary 
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:nqrgui="clr-namespace:NQR_GUI_WPF"
        >
        <Style TargetType="{x:Type nqrgui:ImageButton}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type nqrgui:ImageButton}">
                        <Grid>
                            <ContentControl
                                Content="{TemplateBinding Content}"
                                x:Name="PART_Content"
                                />
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter 
                                    TargetName="PART_Content" 
                                    Property="Content" 
                                    Value="{Binding HighlightedContent, RelativeSource={RelativeSource TemplatedParent}}" 
                                    />
                            </Trigger>
                            <Trigger Property="IsPressed" Value="True">
                                <Setter 
                                    TargetName="PART_Content" 
                                    Property="Content" 
                                    Value="{Binding ClickedContent, RelativeSource={RelativeSource TemplatedParent}}" 
                                    />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
