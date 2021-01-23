    <ListBox x:Name="myListBox">
        <ListBox.ItemContainerStyle>
           <Style TargetType="ListBoxItem">
               <Setter Property="ContextMenu">
                   <Setter.Value>
                       <ContextMenu>
                           <MenuItem Header="First"  IsEnabled="{Binding Path=DataContext.FirstEnabled, ElementName=myListBox}"/>
                           <MenuItem Header="Second"  IsEnabled="{Binding Path=DataContext.SecondEnable, ElementName=myListBox}"/> 
                      </ContextMenu>
                   </Setter.Value>
               </Setter>
           </Style>
       </ListBox.ItemContainerStyle>
    </ListBox>
