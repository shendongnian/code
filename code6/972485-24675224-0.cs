       <Grid>
        <Grid.Resources>
            <Style TargetType="{x:Type HeaderedContentControl}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type HeaderedContentControl}">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition />
                                    <ColumnDefinition />
                                </Grid.ColumnDefinitions>
                                <ContentPresenter ContentSource="Content" />
                                <ContentPresenter ContentSource="Header" Grid.Column="1" VerticalAlignment="Center"/>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <ComboBox Height="23" HorizontalAlignment="Right" Name="comboBox_PC_Opt" VerticalAlignment="Top" Width="130" IsEditable="True" SelectionChanged="comboBox_PC_Opt_SelectionChanged">
            <HeaderedContentControl Header="Blue">
                <Rectangle Fill="Blue" Width="15" Height="15" Margin="0,2,5,2" />
            </HeaderedContentControl>
            <HeaderedContentControl Header="Black">
                <Rectangle Fill="Black" Width="15" Height="15" Margin="0,2,5,2" />
            </HeaderedContentControl>
        </ComboBox>
    </Grid>
