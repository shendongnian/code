                <Image.Style>
                    <Style TargetType="Image">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsMouseOver, RelativeSource={RelativeSource AncestorType=Button}}"
                                         Value="True">
                                <DataTrigger.Setters>
                                    <Setter Property="Effect">
                                        <Setter.Value>
                                            <DropShadowEffect BlurRadius="20"
                                                              Color="Black"
                                                              ShadowDepth="0"
                                                              Opacity="0.5" />
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger.Setters>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Image.Style>
