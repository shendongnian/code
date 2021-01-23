      <Style x:Key="PivotItemStyle1" TargetType="PivotItem">
                <Setter Property="Background" Value="Transparent"/>
                <Setter Property="Margin" Value="{ThemeResource PivotItemMargin}"/>
                <Setter Property="Padding" Value="0"/>
                <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                <Setter Property="VerticalContentAlignment" Value="Stretch"/>
                <Setter Property="IsTabStop" Value="False"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="PivotItem">
                            <Grid Background="{TemplateBinding Background}" HorizontalAlignment="{TemplateBinding HorizontalAlignment}" VerticalAlignment="{TemplateBinding VerticalAlignment}">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="Pivot">
                                        <VisualState x:Name="Right"/>
                                        <VisualState x:Name="Left"/>
                                        <VisualState x:Name="Center"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <!--<ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>-->
                                <Grid >
                                    <GridView x:Name="itemGV" ItemsSource="{Binding Path=Value}">
                                        <GridView.ItemTemplate>
                                            <DataTemplate>
                                                <TextBlock Text="{Binding}" />
                                            </DataTemplate>
                                        </GridView.ItemTemplate>
                                    </GridView>
                                </Grid>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
    <Pivot x:Name="mainContentPivot" 
               Margin="4,10,4,4"
               SelectionChanged="mainContentPivot_SelectionChanged" ItemContainerStyle="{StaticResource PivotItemStyle1}"
              
               >
                <Pivot.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Path=Key}"/>
                    </DataTemplate>
                </Pivot.HeaderTemplate>
                <Pivot.ItemTemplate>
                    <DataTemplate>
                        <Grid/>
                    </DataTemplate>
                </Pivot.ItemTemplate>
            </Pivot>
   
      private void mainContentPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            PivotItem item = (sender as Pivot).ContainerFromItem((sender as Pivot).SelectedItem) as PivotItem;
            var gridView =    FindElementInVisualTree<GridView>(item);
            }
    
        private T FindElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
                {
                    var count = VisualTreeHelper.GetChildrenCount(parentElement);
                    if (count == 0) return null;
        
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(parentElement, i);
                        if (child != null && child is T)
                            return (T)child;
                        else
                        {
                            var result = FindElementInVisualTree<T>(child);
                            if (result != null)
                                return result;
                        }
                    }
                    return null;
                }
