        <Window.Resources>
            <FrameworkElement x:Key="rbTagHolder" Tag="0"/>
        </Window.Resources>
        ...
        <ItemsControl x:Name="RadioButtonList">
            <ItemsControl.ItemTemplate>
               <DataTemplate>
                  <RadioButton Content="{Binding TabName}" Tag="{Binding TagValue}" GroupName="Choice">
                  <i:Interaction.Triggers>
                      <i:EventTrigger EventName="Click">
                        <ei:ChangePropertyAction TargetObject="{DynamicResource rbTagHolder}" PropertyName="Tag" Value="{Binding Tag, RelativeSource={RelativeSource Mode=FindAncestor, AncestorLevel=1, AncestorType={x:Type RadioButton} }}"/>
                      </i:EventTrigger>
                  </i:Interaction.Triggers>
                  </RadioButton>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                   <StackPanel Orientation="Horizontal"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
        ...
        <TabControl x:Name="TabCtrl" SelectedIndex="{Binding Tag, Source={StaticResource rbTagHolder}}"> ... </TabControl>
