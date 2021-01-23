    <ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:local="clr-namespace:FMEA.Resources.Styles"
                    xmlns:Converters="clr-namespace:FMEA.Converters"
                    xmlns:Controls="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro">
    <Style x:Key="Custom_TabItem" BasedOn="{StaticResource {x:Type TabItem}}" TargetType="{x:Type TabItem}">
        <Setter Property="Width">
            <Setter.Value>
                <MultiBinding>
                    <MultiBinding.Converter>
                        <Converters:TabSizeConverter />
                    </MultiBinding.Converter>
                    <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type TabControl}}" />
                    <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type TabControl}}" Path="ActualWidth" />
                </MultiBinding>
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type TabItem}">
                    <Grid x:Name="tabItem">
                        <Border x:Name="Border">
                            <ContentPresenter x:Name="content"
                                              VerticalAlignment="Center"  
					                          HorizontalAlignment="Center"
					                          ContentSource="Header" />
                        </Border>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter Property="Foreground" Value="Gray" />
                        </Trigger>
                        <Trigger Property="IsSelected" Value="False">
                            <Setter Property="Foreground" Value="LightGray" />
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Foreground" Value="Black" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="HeaderTemplate">
            <Setter.Value>
                <DataTemplate DataType="{x:Type TabItem}">
                    <Border x:Name="border">
                        <ContentPresenter>
                            <ContentPresenter.Content>
                                <TextBlock Text="{TemplateBinding Content}"
                                           FontSize="22" HorizontalAlignment="Center" />
                            </ContentPresenter.Content>
                        </ContentPresenter>
                    </Border>
                </DataTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    </ResourceDictionary>
