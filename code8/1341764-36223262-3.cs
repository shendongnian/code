    <MenuItem Header="Example Menu Item" ItemsSource="{Binding ObservableItems}" AlternationCount="{Binding ObservableItems.Count}">
       <MenuItem.ItemContainerStyle>
          <Style TargetType="{x:Type MenuItem}">
             <Setter Property="Command" Value="{Binding ...}"/>
             <Setter Property="CommandParameter" Value="{Binding RelativeSource={RelativeSource Self}, Path=(ItemsControl.AlternationIndex)}"/>
          </Style>
       </MenuItem.ItemContainerStyle>
    </MenuItem>
