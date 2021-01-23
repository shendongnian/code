    private void LogToForm(object line, string eventTime, Log.Severity severity) {
                if (dataGridView_LogInfo.InvokeRequired) {
                    dataGridView_LogInfo.Invoke (
                        new Action<object, string, Log.Severity>(LogtoFormCallback), 
                        new object[] { line, eventTime, severity }
                    );
                    
                } else {
                    LogtoFormCallback(line, eventTime, severity);
                }
            }
