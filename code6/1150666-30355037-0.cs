    <Button ToolTip="Attach Approval" 
            Height="25" 
    
            Margin="5,10,5,10">
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <!-- Default Content value -->
                <Setter Property="Command" Value="{Binding AddAttachmentCommand}"/>
                <Setter Property="Content">
                    <Setter.Value>
                        <StackPanel Orientation="Horizontal">
                            <Image Source="/UILibrary;component/Themes/Default/Images/Attach.PNG"/>
                        </StackPanel>
                    </Setter.Value>
                </Setter>
    
                <!-- Triggered values -->
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsAttachmentAvailable}" Value="True">
                        <Setter Property="Visibility" Value="Visible"/>
                        <Setter Property="Content" Value="Appprove"/>
                        <Setter Property="Command" Value="SOME OTHER COMMAND"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsAttachmentAvailable}" Value="False">
                        <Setter Property="Visibility" Value="Visible"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
