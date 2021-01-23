    <UserControl.Resources>
        <Style TargetType={x:Type Grid}>
            <Style.Triggers>
                 <MultiDataTrigger>
                      <MultiDataTrigger.Conditions>
                          <Condition Binding="{ElementName=cb1, Path=IsChecked}" Value="True">
                          <Condition Binding="{ElementName=cb2, Path=IsChecked}" Value="True">
                      </MultiDataTrigger.Conditions>
                      <Setter Property="IsEnabled" Value="True" />
                 </MultiDataTrigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
    <CheckBox x:Name="cb1" />
    <CheckBox x:Name="cb2" />
