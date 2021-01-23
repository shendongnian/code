    <ComboBox x:Name="_server"/>
    <ComboBox x:Name="_computer">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedItem,
                                                   ElementName=_server}"
                                 Value="{x:Null}">
                        <Setter Property="IsEnabled" Value="False"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox>
