    <ComboBox IsTextSearchEnabled="True" StaysOpenOnEdit="True" 
              Width="150" Height="24"  IsReadOnly="False" IsEditable="True">
      <ComboBox.Resources>
        <VisualBrush x:Key="HelpBrush" TileMode="None" Opacity="0.4" Stretch="None" AlignmentX="Left">
          <VisualBrush.Visual>
            <TextBlock FontStyle="Italic" Text="Type or select from list"/>
          </VisualBrush.Visual>
        </VisualBrush>
      </ComboBox.Resources>
      <ComboBox.Style>
        <Style TargetType="ComboBox">
          <Style.Triggers>
            <Trigger Property="Text" Value="{x:Null}">
              <Setter Property="Background" Value="{StaticResource HelpBrush}"/>
            </Trigger>
            <Trigger Property="Text" Value="">
              <Setter Property="Background" Value="{StaticResource HelpBrush}"/>
            </Trigger>
          </Style.Triggers>
        </Style>
      </ComboBox.Style>
      <ComboBoxItem>First item</ComboBoxItem>
      <ComboBoxItem>Another item</ComboBoxItem>
    </ComboBox>
