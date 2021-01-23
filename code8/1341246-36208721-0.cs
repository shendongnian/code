    <Button>
        <Button.Template>
            <ControlTemplate TargetType="Button">
                <Image Name="img1" Source="Images/ContentImage.png" />
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="true">
                        <Setter TargetName="img1"  Property="Source"  Value="Images/ContentImage1.png" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Button.Template>
    </Button>
