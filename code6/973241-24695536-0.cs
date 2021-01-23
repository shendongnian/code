        <ScrollViewer VerticalScrollBarVisibility="auto" x:Name="scroll">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition />
                    <ColumnDefinition Width="auto" />
                </Grid.ColumnDefinitions>
                <Border Background="LightGoldenrodYellow"
                        Height="300" />
                <Border Grid.Column="1" Background="AliceBlue"
                        Width="{x:Static SystemParameters.VerticalScrollBarWidth}">
                    <Border.Style>
                        <Style TargetType="Border">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding ComputedVerticalScrollBarVisibility, ElementName=scroll}"
                                             Value="Visible">
                                    <Setter Property="Visibility"
                                            Value="Collapsed" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Border.Style>
                </Border>
            </Grid>
        </ScrollViewer>
