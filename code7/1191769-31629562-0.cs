        <TextBlock x:Name="MyTextBlock"  VerticalAlignment="Center" >
            <TextBlock.Resources>
                <Style TargetType="{x:Type TextBlock}">
                    <Setter Property="Background" Value="Blue"/>
                    <Setter Property="Text">
                        <Setter.Value>
                            <MultiBinding Converter="{StaticResource GeneralMultiStringDisplayConverter}">
                                <Binding Path="RatesViewModel.Instrument.Currency" NotifyOnSourceUpdated="True" UpdateSourceTrigger="PropertyChanged"/>
                                <Binding Path="RatesViewModel.Instrument.Underlying" NotifyOnSourceUpdated="True" UpdateSourceTrigger="PropertyChanged"/>
                                <Binding Path="RatesViewModel.Instrument.ProductType" NotifyOnSourceUpdated="True" UpdateSourceTrigger="PropertyChanged"/>
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=Text}" Value="{x:Null}">
                            <!--THIS SHOULD FIRE-->
                            <Setter Property="Text" Value="ThisShouldFireOnStart"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Resources>
        </TextBlock>
