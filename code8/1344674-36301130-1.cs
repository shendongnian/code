              <Style TargetType="MenuItem">
                    <Setter Property="ItemsSource" Value="{Binding Children}"/>
                        <Setter Property="ItemsPanel">
                            <Setter.Value>
                                <ItemsPanelTemplate>
                                    <WrapPanel MaxHeight="300" Orientation="Vertical"/>
                                </ItemsPanelTemplate>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="ItemContainerStyle">
                        <Setter.Value>
                                <Style TargetType="MenuItem">
                                    <Setter Property="ItemsSource" Value="{Binding Children}"/>
                                    <Setter Property="ItemsPanel">
                                        <Setter.Value>
                                            <ItemsPanelTemplate>
                                                <WrapPanel MaxHeight="300" Orientation="Vertical"/>
                                            </ItemsPanelTemplate>
                                        </Setter.Value>
                                    </Setter>
                                    <Setter Property="ItemContainerStyle">
                                        <Setter.Value>
                                            <Style TargetType="MenuItem">
                                                <Setter Property="ItemsSource" Value="{Binding Children}"/>
                                                <Setter Property="ItemsPanel">
                                                    <Setter.Value>
                                                        <ItemsPanelTemplate>
                                                            <WrapPanel MaxHeight="300" Orientation="Vertical"/>
                                                        </ItemsPanelTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </Setter.Value>
                    </Setter>   
                </Style>
