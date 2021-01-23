    <ContentControl Content="{Binding}">
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsImage}" Value="True">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>                                                        
                                <DataTemplate>
                                    <TextBlock Text="Text goes here"
                                Foreground="Red"/>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsImage}" Value="False">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Itemsource}"/>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
    
