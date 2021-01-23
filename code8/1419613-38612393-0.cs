    <Window.Resources>
            <local:ImageList x:Key="SliderViewModel"></local:ImageList>
    </Window.Resources>
    
        <Image Source="{Binding CurrentImage.Source, Mode=OneWay}" Grid.Row="0" Grid.Column="1">
            <Image.ContextMenu>
                   <ContextMenu>
                         <MenuItem Header="Edit Image" Command="{Binding EditImageCommand, Source={StaticResource SliderViewModel}}"></MenuItem>
                     </ContextMenu>
             </Image.ContextMenu>
         </Image>
