        using (var transactionScope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                IEnumerable<Object> results = null;
                using (Runspace runSpace = RunspaceFactory.CreateRunspace())
                {
                    runSpace.Open();
                    using (Pipeline pipeline = runSpace.CreatePipeline())
                    {
                        Command command = new Command(script, true, true);
                        if (parameters != null && parameters.Any())
                            foreach (var param in parameters)
                                command.Parameters.Add(param.Key, param.Value);
                        pipeline.Commands.Add(command);
                        results = pipeline.Invoke();
                    }
                    runSpace.Close();
                    transactionScope.Complete();
                    return results;
                }
            }
