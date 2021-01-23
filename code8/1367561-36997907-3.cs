      <Style x:Key="ChangeContentOnMouseOver" TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="False">
                    <Setter Property="Content">
                        <Setter.Value>
                            <Image Source="Images/RedButtonBackGround.jpg"/>
                        </Setter.Value>
                    </Setter>
                </Trigger>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Content">
                        <Setter.Value>
                            <Image Source="Images/Koala.jpg"/>
                        </Setter.Value>
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
