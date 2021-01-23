    <Button Content="WithConverter" Command="{Binding WithConverterCommand}">
                <Button.CommandParameter>
                    <MultiBinding Converter="{StaticResource MultiInOneConverter}">
                        <Binding>
                            <Binding.Source>
                                <local:StyleModes>Somex</local:StyleModes>
                            </Binding.Source>
                        </Binding>
                        <Binding>
                            <Binding.Source>
                                <local:StyleModes>Somey</local:StyleModes>
                            </Binding.Source>
                        </Binding>
                    </MultiBinding>
                </Button.CommandParameter>
    </Button>
