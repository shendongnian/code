    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
    <Window.Resources>
        <Style x:Key="ConfirmCancelButton" TargetType="{x:Type ToggleButton}">
            <Setter Property="IsThreeState" Value="True"/>
            <Style.Triggers>
                <!-- Button is not clicked (original state) -->
                <Trigger Property="IsChecked" Value="False">
                    <Setter Property="Foreground" Value="{DynamicResource TextBrush}"/>
                </Trigger>
                <!-- Button clicked once (waiting for 2nd click)-->
                <Trigger Property="IsChecked" Value="True">
                    <Setter Property="Foreground" Value="Orange"/>
                </Trigger>
                <!-- Button clicked twice (executing cancel command)-->
                <Trigger Property="IsChecked" Value="{x:Null}">
                    <Setter Property="Foreground" Value="Red"/>
                </Trigger>
                <!-- Button lost it's focus (back to the original state)-->
                <Trigger Property="IsFocused" Value="False">
                    <Setter Property="IsChecked" Value="False"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    
    <Window>
        <Grid>
            <ToggleButton Grid.Row="1" Style="{StaticResource ConfirmCancelButton}" Content="Cancel" >
                <i:Interaction.Triggers>
                    <!-- if IsChecked=="{x:Null}" -->
                    <i:EventTrigger EventName="Indeterminate">
                        <i:InvokeCommandAction Command="{Binding CancelCommand}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </ToggleButton>
        </Grid>
    </Window>
