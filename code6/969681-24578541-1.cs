    <ContentControl Content="{Binding}">
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <local:UserControlA/>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding View}" Value="B">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <local:UserControlB/>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
