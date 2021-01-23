     <Grid Background="Purple">
        
        <ContentControl x:Name="fixedContent" Margin="0,75,0,0">
            <ContentControl.Style>
                <Style TargetType="{x:Type ContentControl}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding FixedContent, Mode=OneWay}" Value="false">
                            <DataTrigger.Setters>
                                <Setter Property="Content" Value="{StaticResource ContentKey}"/>                               
                            </DataTrigger.Setters>
                        </DataTrigger>                        
                    </Style.Triggers>
                </Style>
            </ContentControl.Style>
        </ContentControl>
        
        <Grid Background="Red" Margin="0,54,0,0">
            <ContentControl x:Name="resizableContent" Margin="0,75,0,0">
                <ContentControl.Style>
                    <Style TargetType="{x:Type ContentControl}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding FixedContent, Mode=OneWay}" Value="true">
                                <DataTrigger.Setters>
                                    <Setter Property="Content" Value="{StaticResource ContentKey}"/>
                                </DataTrigger.Setters>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
            </ContentControl>
        </Grid>
    </Grid>
