        <DataGridTemplateColumn.CellTemplate>                        
                <DataTemplate>                            
                        <TextBox VerticalAlignment="Stretch" VerticalContentAlignment="Center"  Loaded="TextBox_Loaded" PreviewLostKeyboardFocus="TextBox_PreviewLostKeyboardFocus" PreviewKeyUp="TextBox_PreviewKeyUp">
                                <TextBox.Triggers>
                                </TextBox.Triggers>
                                    <TextBox.Text>
                                    <Binding Path="ID" UpdateSourceExceptionFilter="ReturnExceptionHandler" UpdateSourceTrigger="PropertyChanged" ValidatesOnDataErrors="True" ValidatesOnExceptions="True" >
                                        <Binding.ValidationRules>
                                            <v:CustomValidRule ValidationStep="ConvertedProposedValue"></v:CustomValidRule>
                                        </Binding.ValidationRules>
                                    </Binding>
                            </TextBox.Text>
                        </TextBox>
                    </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
