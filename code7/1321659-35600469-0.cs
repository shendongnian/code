    <UserControl>
        <UserControl.Template>
            <ControlTemplate>
                <ControlTemplate.Triggers>
                    <DataTrigger Binding="{Binding PopupOpened}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource ShowPopup}" />
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </ControlTemplate.Triggers>
                <!-- Some content for template to have substance -->
                <TextBlock />
            </ControlTemplate>
        </UserControl.Template>
    </UserControl>
