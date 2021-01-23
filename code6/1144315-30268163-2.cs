            // Step 2: If no command, check class input bindings
            if (command == null)
            {
                lock (_classInputBindings.SyncRoot)
                {
                    Type classType = targetElement.GetType();
                    while (classType != null)
                    {
                        InputBindingCollection classInputBindings = _classInputBindings[classType] as InputBindingCollection;
                        if (classInputBindings != null)
                        {
                            InputBinding inputBinding = classInputBindings.FindMatch(targetElement, inputEventArgs);
                            if (inputBinding != null)
                            {
                                command = inputBinding.Command;
                                target = inputBinding.CommandTarget;
                                parameter = inputBinding.CommandParameter;
                                break;
                            }
                        }
                        classType = classType.BaseType;
                    }
                }
            }
 
