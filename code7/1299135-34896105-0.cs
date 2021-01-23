     <Expander>
                <Rectangle Height="500" Width="500" Fill="Red"/>
                <Expander.Template>
                    <ControlTemplate TargetType="Expander">
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition Height="20"/>
                            </Grid.RowDefinitions>
                            <ContentPresenter Grid.Row="0" x:Name="ContentPresenter"/>
                            <ToggleButton Grid.Row="1" IsChecked="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=IsExpanded}"/>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsExpanded" Value="True">
                                <Setter TargetName="ContentPresenter" Property="Visibility" Value="Visible"/>
                            </Trigger>
                            <Trigger Property="IsExpanded" Value="False">
                                <Setter TargetName="ContentPresenter" Property="Visibility" Value="Collapsed"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Expander.Template>
            </Expander>
