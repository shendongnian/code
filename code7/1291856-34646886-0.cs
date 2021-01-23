    <DataTemplate DataType="{x:Type local:Message}">
            <ContentControl Content="{Binding Direction}">
                <ContentControl.Style>
                    <Style TargetType="{x:Type ContentControl}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Direction}" Value="{x:Static local:MessageDirection.Inbound}">
                                <Setter Property="ContentTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <Button Background="Green">Inbound</Button>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding Direction}" Value="{x:Static local:MessageDirection.Outbound}">
                                <Setter Property="ContentTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <Button Background="Red">Outbound</Button>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
            </ContentControl>
        </DataTemplate>
