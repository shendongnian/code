     <ContextMenu ItemsSource="{Binding ContextActions}">                    
         <ContextMenu.ItemContainerStyle>
              <Style TargetType="{x:Type MenuItem}" >
                    <Setter Property="Header" Value="{Binding Title}"/>
                    <Setter Property="ToolTip" Value="{Binding ToolTips}"/>
                    <Setter Property="Command" Value="{Binding ContextCommand}"/>
                    <Setter Property="Icon" Value="{StaticResource Icon}"/>
                    <Setter Property="CommandParameter" Value="{Binding CommandParameter}"/>
               </Style>
         </ContextMenu.ItemContainerStyle>
     </ContextMenu>
