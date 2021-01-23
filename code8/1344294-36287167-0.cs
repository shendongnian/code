        public TResult Until<TResult>(Func<T, TResult> condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException("condition", "condition cannot be null");
            }
            var resultType = typeof(TResult);
            if ((resultType.IsValueType && resultType != typeof(bool)) || !typeof(object).IsAssignableFrom(resultType))
            {
                throw new ArgumentException("Can only wait on an object or boolean response, tried to use type: " + resultType.ToString(), "condition");
            }
            Exception lastException = null;
            var endTime = this.clock.LaterBy(this.timeout);
            while (true)
            {
                try
                {
                    var result = condition(this.input);
                    if (resultType == typeof(bool))
                    {
                        var boolResult = result as bool?;
                        if (boolResult.HasValue && boolResult.Value)
                        {
                            return result;
                        }
                    }
                    else
                    {
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!this.IsIgnoredException(ex))
                    {
                        throw;
                    }
                    lastException = ex;
                }
                // Check the timeout after evaluating the function to ensure conditions
                // with a zero timeout can succeed.
                if (!this.clock.IsNowBefore(endTime))
                {
                    string timeoutMessage = string.Format(CultureInfo.InvariantCulture, "Timed out after {0} seconds", this.timeout.TotalSeconds);
                    if (!string.IsNullOrEmpty(this.message))
                    {
                        timeoutMessage += ": " + this.message;
                    }
                    this.ThrowTimeoutException(timeoutMessage, lastException);
                }
                Thread.Sleep(this.sleepInterval);
            }
        }
