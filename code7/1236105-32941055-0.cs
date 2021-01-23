            // The show command will return the decision from the user how to proceed with a error.
            // The UserError will have a number of recovery options associated with it, which the dialog 
            // will present to the user. In testing mode this will likely be the test triggering the recovery command.
            // We will wait until one of those recovery commands is executed, then get the result from it.
            ShowCommand = ReactiveCommand.CreateAsyncObservable(x =>
            {
                var userError = x as UserError;
                // We must always have a valid user error. 
                if (userError == null)
                {
                    return Observable.Throw<RecoveryOptionResult>(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Expected a UserError but got {0}", x)));
                }
                Error = userError;
                Message = Error.ErrorMessage;
                // This fancy statement says go through all the recovery options we are presenting to the user
                // subscribe to their is executing event, if the event fires, get the return result and pass that back
                // as our return value for this command.
                return (Error.RecoveryOptions.Select(cmd => cmd.IsExecuting.SelectMany(_ => !cmd.RecoveryResult.HasValue ? Observable.Empty<RecoveryOptionResult>() : Observable.Return(cmd.RecoveryResult.Value)))).Merge().Take(1);
            });
