    if (PostRichEditBox.IsTextPredictionEnabled)
                    {
                       this.Focus(Windows.UI.Xaml.FocusState.Keyboard);
                        var scope = new InputScope();
                        var inputScopeName = new InputScopeName { NameValue = InputScopeNameValue.NameOrPhoneNumber };
                        scope.Names.Add(inputScopeName);
                        PostRichEditBox.InputScope = scope;
                        PostRichEditBox.IsTextPredictionEnabled = false;
                        PostRichEditBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
                     }
