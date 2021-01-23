     <Style TargetType="{x:Type DataGridColumnHeader}" x:Key="DummyFilterDataGridColumnHeader">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DataGridColumnHeader}">
                            <StackPanel Name="ButtonsPanel">
                                <Button Name="BtnSuper1" Content="Super I" Visibility="Collapsed">
                                    <Button.Style>
                                        <Style TargetType="Button">
                                            <Setter Property="Visibility" Value="Collapsed"/>
                                        </Style>
                                    </Button.Style>
                                </Button>
                                <Button Name="BtnSuper2" Content="Super II" Visibility="Collapsed">
                                    <Button.Style>
                                        <Style TargetType="Button">
                                            <Setter Property="Visibility" Value="Collapsed"/>
                                        </Style>
                                    </Button.Style>
                                </Button>
                                <Button  Name="BtnSuper3" Content="Super III" Visibility="Collapsed" >
                                    <Button.Style>
                                        <Style TargetType="Button">
                                            <Setter Property="Visibility" Value="Collapsed"/>
                                        </Style>
                                    </Button.Style>
                                </Button>
                            </StackPanel>
                            <ControlTemplate.Triggers>
                                <DataTrigger Binding="{Binding HashCodeValue}" Value="Give Your HashCode for matching ">
                                    <Setter TargetName="BtnSuper1" Property="Visibility" Value="Visible" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding HashCodeValue}" Value="Give Your HashCode for matching">
                                    <Setter TargetName="BtnSuper2" Property="Visibility" Value="Visible" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding HashCodeValue}" Value="Give Your HashCode for matching ">
                                    <Setter TargetName="BtnSuper3" Property="Visibility" Value="Visible" />
                                </DataTrigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
