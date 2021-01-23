      <Window.Resources>
        <DataTemplate x:Key="ExpanderHeaderTemplate">
            <Grid Background="#939393">
                <Grid.RowDefinitions>
                    <RowDefinition Height="22"/>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="20"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Grid.Resources>
                    <Style TargetType="{x:Type ToggleButton}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type ToggleButton}">
                                    <Border HorizontalAlignment="Center" VerticalAlignment="Center" x:Name="border" CornerRadius="5,5,5,5" 
                                        Background="{TemplateBinding Background}" BorderBrush="#FF000000" Margin="1" BorderThickness="1,1,1,1" SnapsToDevicePixels="True">
                                        <ContentPresenter x:Name="contentPresenter"/>
                                    </Border>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsChecked" Value="true">
                                            <Setter Property="Background" TargetName="border" Value="DarkGray"/>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Grid.Resources>
                <TextBlock Grid.Column="0" Background="#6E6E6E"/>
                <ToggleButton Grid.Column="0" Background="Red" IsChecked="{Binding IsExpanded, Mode=TwoWay, RelativeSource={RelativeSource FindAncestor, AncestorType=Expander}}" Focusable="False">
                    <Image Source="{Binding IsExpanded, RelativeSource={RelativeSource FindAncestor, AncestorType=Expander}, Converter={StaticResource boolToExpanderDirectionConverter}}"/>
                </ToggleButton>
                <TextBlock Grid.Column="1" Text="{Binding Path=Header,RelativeSource={RelativeSource AncestorType={x:Type Expander}}}" Margin="5,1,1,1" VerticalAlignment="Top" FontWeight="Bold"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
     <StackPanel>
        <Expander Header="General1" HeaderTemplate="{StaticResource ExpanderHeaderTemplate}"/>
        <Expander Header="General2" HeaderTemplate="{StaticResource ExpanderHeaderTemplate}"/>
    </StackPanel>
       
