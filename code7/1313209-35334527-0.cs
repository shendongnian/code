    <Style TargetType="SetHereTheTypeOfDataContextMenyTargetControl">
            <Setter Property="dataGridCreateColumnAndBindIteFromCodeBehind:Attached.ParentDataContextToTag" Value="True"></Setter>
             <Setter Property="ContextMenu">
                 <Setter.Value>
                    <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                        <MenuItem Header="MenuItem One"
                                  Command="{Binding CmdMenuItemOne}" />
                        <MenuItem Header="MenuItem Two" 
                                  Command="{Binding CmdMenuItemTwo}" />
                    </ContextMenu>
                </Setter.Value>
             </Setter>
         </Style>
