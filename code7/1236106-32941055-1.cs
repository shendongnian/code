            var retryCommand = new RecoveryCommand("Retry") { IsDefault = true };
            retryCommand.Subscribe(_ => retryCommand.RecoveryResult = RecoveryOptionResult.RetryOperation);
            var userError = new UserError(errorMessage, errorResolution, new[] { retryCommand, RecoveryCommand.Cancel });
            switch (await UserError.Throw(userError))
            {
                case RecoveryOptionResult.RetryOperation:
                    await Setup();
                    break;
                case RecoveryOptionResult.FailOperation:
                case RecoveryOptionResult.CancelOperation:
                    if (HostScreen.Router.NavigateBack.CanExecute(null))
                    {
                        HostScreen.Router.NavigateBack.Execute(null);
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
