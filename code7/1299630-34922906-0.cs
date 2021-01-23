     <Expander Grid.Row="3" Grid.ColumnSpan="2" Name="expander" Width="500">
                <Expander.Resources>
                    <local:ExpanderHeaderConverter x:Key="ExpanderHeaderConverter" />
                </Expander.Resources>
                <Expander.Header>
                    <TextBlock >
                        <TextBlock.Text>
                            <MultiBinding Converter="{StaticResource ExpanderHeaderConverter}">
                                <Binding ElementName="c1" Mode="OneWay"/>        
                                <Binding ElementName="c1" Mode="OneWay" Path="IsChecked"/>
                                <Binding ElementName="c2" Mode="OneWay"/>         
                                <Binding ElementName="c2" Mode="OneWay" Path="IsChecked"/>
                                <Binding ElementName="c3" Mode="OneWay"/>
                                <Binding ElementName="c3" Mode="OneWay" Path="IsChecked"/>
                            </MultiBinding>
                        </TextBlock.Text>
                    </TextBlock>
                </Expander.Header>
                <StackPanel>
                    <CheckBox Name="c1" >Test 1</CheckBox>
                    <CheckBox Name="c2">Test 2</CheckBox>
                    <CheckBox Name="c3">Test 3</CheckBox>
                </StackPanel>
            </Expander>
