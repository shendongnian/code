    public WebAuthenticationBrokerContinuationEventArgs WABContinuationArgs { get; set; }
            
            private void Application_ContractActivated(object sender, IActivatedEventArgs e)
                    {
                        var _WABContinuationArgs = e as WebAuthenticationBrokerContinuationEventArgs;
            
                        if (_WABContinuationArgs != null)
                        {
                            WABContinuationArgs = _WABContinuationArgs;
                            var result = WABContinuationArgs.WebAuthenticationResult;
                        }
                    }
