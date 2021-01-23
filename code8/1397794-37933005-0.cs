        <Style TargetType="{x:Type RadioButton}">
            <Setter Property="Width" Value="15"/>
            <Setter Property="Height" Value="15"/>
            <Setter Property="VerticalAlignment" Value="Bottom"/>
            <Setter Property="Margin" Value="4,0,4,0" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="RadioButton">
                        <Rectangle Name="rectangle" Width="15"    Height="15" Fill="{DynamicResource BlackBrush}">
                            <Rectangle.Resources>
                                <SolidColorBrush x:Key="BlackBrush" Color="#496161" />
                            </Rectangle.Resources>
                        </Rectangle>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter TargetName="rectangle" Property="Fill" Value="Red" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
            <RadioButton IsChecked="False">click me</RadioButton>
            <RadioButton IsChecked="True">click me too</RadioButton>
