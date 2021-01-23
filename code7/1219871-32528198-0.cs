    <CheckBox>
            <CheckBox.Template>
                <ControlTemplate TargetType="CheckBox">
                    <Grid>
                        <Image  Source="pack://siteoforigin:,,,/Pics/bulb_off.jpg" Width="40" Height="60"  />
                        <Image  Source="pack://siteoforigin:,,,/Pics/bulb_on.jpg" Width="40" Height="60" Name="CheckMark" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsChecked" Value="false">
                            <Setter TargetName="CheckMark" Property="Visibility" Value="Hidden"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </CheckBox.Template>
        </CheckBox>
