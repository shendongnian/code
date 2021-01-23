    <Button
        Name="btn_close_resume"
        Command="{Binding CloseResumeCommand}"
        CommandParameter="{Binding ElementName=dg, Path=SelectedItem}">
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="Content" Value="Resume Task"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedTask}" Value="{x:Null}">
                            <Setter Property="IsEnabled" Value="False"></Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding SelectedTask.EndDate}" Value="{x:Null}">
                            <Setter Property="Content" Value="End Task"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
