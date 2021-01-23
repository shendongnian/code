            <Style TargetType="{x:Type DataGridCell}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Path=Column.Header, Mode=OneWay, 
                                            Converter={StaticResource StringComparisonToBooleanConverter}, ConverterParameter=DestinationCodeType}" Value="True">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                   <ComboBox Name="TransposeCodeComboBox"
                                             IsReadOnly="True" 
                                             ItemsSource="{Binding Source={StaticResource TransposeCodeTypeCollection}}"
                                             SelectedValue="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Path=DataContext.DestinationCodeType, Mode=TwoWay}"
                                             IsSynchronizedWithCurrentItem="False"
                                             Margin="0"
                                             Width="Auto"
                                             Height="Auto" />
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
