    DisplayModeProvider.Instance.Modes
    .Add(new DefaultDisplayMode("Mobile")
                    {
                        ContextCondition = context => {
                            var userAgent = context.GetOverriddenUserAgent();
                            return userAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) > -1
                                   && userAgent.IndexOf("Mobile", StringComparison.OrdinalIgnoreCase) > -1
                                   && userAgent.IndexOf("Firefox", StringComparison.OrdinalIgnoreCase) > -1;
                        }
                    });
                
