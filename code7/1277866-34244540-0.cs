    <Window.Resources>
       <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
       <Style TargetType="{x:Type Expander}">
          <Setter Property="Template">
             <Setter.Value>
                <ControlTemplate TargetType="{x:Type Expander}">
                   <Grid>
                      <Grid.RowDefinitions>
                         <RowDefinition Height="30"/>
                         <RowDefinition Height="Auto" Name="contentRow"/>
                      </Grid.RowDefinitions>
                      <!--Expander Header-->
                      <Border Background="AliceBlue" Grid.Row="0">
                         <Grid>
                            <Grid.ColumnDefinitions>
                               <ColumnDefinition Width="*"/>
                               <ColumnDefinition Width="20"/>
                            </Grid.ColumnDefinitions>
                            <ContentPresenter Grid.Column="0" ContentSource="Header" RecognizesAccessKey="True" VerticalAlignment="Center" HorizontalAlignment="Left" Margin="5" />
                            <ToggleButton Grid.Column="1" Content="x" IsChecked="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=IsExpanded}"/>
                         </Grid>
                      </Border>
                      <!--Expander Content-->
                      <Border Background="Aqua" Grid.Row="1" Visibility="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=IsExpanded, Converter={StaticResource BooleanToVisibilityConverter}}">
                         <ContentPresenter/>
                      </Border>
                   </Grid>
                </ControlTemplate>
             </Setter.Value>
          </Setter>
       </Style>
    </Window.Resources>
