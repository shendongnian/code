    <MenuItem Header="Add Exisiting Properties" ItemsSource="{Binding Path=AvailableProperties}">
        <MenuItem.Resources>
          <Style TargetType="MenuItem">
             <Setter Property="HeaderTemplate">
                  <Setter.Value>
                     <DataTemplate>
                         <StackPanel Orientation="Horizontal">                                                                  
    <ContentPresenter Content="{TemplateBinding Header}" />
                         </StackPanel>
                     </DataTemplate>
                  </Setter.Value>
             </Setter>
 or 
    <MenuItem Header="Add Exisiting Properties" ItemsSource="{Binding Path=AvailableProperties}">
                <MenuItem.Resources>
                  <Style TargetType="MenuItem">
                     <Setter Property="HeaderTemplate">
                       <Setter.Value>
                           <DataTemplate>
                             <StackPanel Orientation="Horizontal">                                                                     
        <ContentPresenter Content="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Header}" />
                             </StackPanel>
                           </DataTemplate>
                        </Setter.Value>
                     </Setter>
`
