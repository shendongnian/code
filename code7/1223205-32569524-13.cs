    <TextBox VerticalAlignment="Stretch" VerticalContentAlignment="Center" Loaded="TextBox_Loaded">
                                <TextBox.Text>
                                        <Binding Path="ID" UpdateSourceExceptionFilter="ReturnExceptionHandler" UpdateSourceTrigger="PropertyChanged" ValidatesOnDataErrors="True" ValidatesOnExceptions="True" >
                                            <Binding.ValidationRules>
                                                <b:CustomValidRule ValidationStep="ConvertedProposedValue"></b:CustomValidRule>
                                            </Binding.ValidationRules>
                                        </Binding>
                                </TextBox.Text>
                            </TextBox>
//////////////////////
    private void TextBox_Loaded(object sender, RoutedEventArgs e)
            {
                Collection<ValidationRule> rules= ((TextBox)sender).GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules;
    
                foreach (ValidationRule rule in rules)
                    vm.Rules.Add(rule);
            }
