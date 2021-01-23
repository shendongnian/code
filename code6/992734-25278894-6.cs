    <Style TargetType="FrameworkElement" x:Key="VisibleAnimation">
      <Setter Property="Visibility" Value="Collapsed"/>
      <Setter Property="Opacity" Value="0"/>
      <Style.Triggers>
        <Trigger Property="Visibility" Value="Visible">
          <Trigger.EnterActions>
            <BeginStoryboard>
              <Storyboard>
                <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                 From="0.0" To="1.0" Duration="0:0:0.2"/>
              </Storyboard>
            </BeginStoryboard>
          </Trigger.EnterActions>
        </Trigger>
      </Style.Triggers>
    </Style>
    <DockPanel Background="#151515" LastChildFill="True" Style="{StaticResource VisibleAnimation}" Name="TopMenuArea"  Height="55">
