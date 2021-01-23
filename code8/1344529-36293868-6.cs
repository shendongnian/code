    <ItemsControl
        xmlns:test="clr-namespace:EdTest"
        ItemsSource="{test:EnumEnumerator test:TestEnum}"
        >
        <ItemsControl.Resources>
            <test:FlagCheckConverter x:Key="FlagChecker" />
        </ItemsControl.Resources>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border 
                    x:Name="Border"
                    Padding="6" 
                    Width="80" 
                    Height="60" 
                    BorderBrush="SteelBlue" 
                    BorderThickness="1,1,0,0"
                    >
                    <ContentControl Content="{Binding}" />
                </Border>
                <DataTemplate.Triggers>
                    <DataTrigger Value="False">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource FlagChecker}">
                                <!-- The DataContext value - a single enum value -->
                                <Binding />
                                <Binding 
                                    Path="DataContext.TestFlags" 
                                    RelativeSource="{RelativeSource AncestorType=ItemsControl}" 
                                    />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter TargetName="Border" Property="Visibility" Value="Collapsed" />
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel 
                    Orientation="Horizontal" 
                    />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>
