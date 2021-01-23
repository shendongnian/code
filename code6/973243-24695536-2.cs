    <Grid>
        <Grid.Resources>
            <ControlTemplate x:Key="ReservedSpaceScroller" TargetType="ContentControl">
                <ScrollViewer VerticalScrollBarVisibility="auto"
                              x:Name="scroll">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition Width="auto" />
                        </Grid.ColumnDefinitions>
                        <ContentPresenter />
                        <Border Width="{x:Static SystemParameters.VerticalScrollBarWidth}"
                                x:Name="placeholder" Grid.Column="1" />
                    </Grid>
                </ScrollViewer>
                <ControlTemplate.Triggers>
                    <DataTrigger Binding="{Binding ComputedVerticalScrollBarVisibility, ElementName=scroll}"
                                 Value="Visible">
                        <Setter TargetName="placeholder"
                                Property="Visibility"
                                Value="Collapsed" />
                    </DataTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Grid.Resources>
        <ContentControl Template="{StaticResource ReservedSpaceScroller}">
            <Border Background="LightGoldenrodYellow"
                    Height="300" />
        </ContentControl>
    </Grid>
