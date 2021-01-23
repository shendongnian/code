    <StackPanel>
        <TextBox>
            <TextBox.Style>
                <Style TargetType="TextBox">
                    <Setter Property="Text" Value="{Binding Name, Mode=OneWay}"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsFocused}" Value="True">
                            <Setter Property="Text" Value="{Binding Name, Mode=OneWayToSource, UpdateSourceTrigger=LostFocus}"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
           </TextBox>
        <Button Content="Click"/>
    </StackPanel>
