        <ComboBox x:Name="cbDocket" HorizontalAlignment="Left" Margin="33,30,0,269" Width="124" IsEditable="True">
            <ComboBox.ContextMenu>
                <ContextMenu Name="Menu">
                    <MenuItem Header="Remove" Click="cbDocket_MenuItemRemove"/>
                </ContextMenu>
            </ComboBox.ContextMenu>
            <ComboBox.ItemContainerStyle>
                <Style TargetType="{x:Type ComboBoxItem}">
                    <EventSetter Event="MouseMove" Handler="cbDocket_OnMouseMove" />
                </Style>
            </ComboBox.ItemContainerStyle> 
    </ComboBox>
