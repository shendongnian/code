    void AddError(string propertyName, string messageText)
            {
                List<string> errList;
                if (errors.TryGetValue(propertyName, out errList))
                {
                    if (!errList.Contains(messageText))
                    {
                        errList.Add(messageText);
                        errors.Remove(propertyName);
                        OnErrorsChanged(propertyName);
                        if (errList != null)
                            errors.Add(propertyName, errList);
                    }
                }
                else
                {
                    errList = new List<string> { messageText };
                    errors.Add(propertyName, errList);
                    OnErrorsChanged(propertyName);
                }
            }
            void RemoveError(string propertyName, string messageText)
            {
                List<string> errList;
                if (errors.TryGetValue(propertyName, out errList))
                {
                    errList.Remove(messageText);
                    errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
                if (errList != null)
                    errors.Add(propertyName, errList);
    
            }
