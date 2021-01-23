    namespace nicknow.Logging
    {
        static class NonSandboxedExceptionLogging
        {
            ///From the example at http://stackoverflow.com/a/12827271/394978
            /// <summary>
            /// This utility method can be used for retrieving extra details from exception objects. Cannot be used in code running in the Dynamics CRM Sandbox
            /// </summary>
            /// <param name="e">Exception.</param>
            /// <param name="indent">Optional parameter. String used for text indent.</param>
            /// <returns>String with as much details was possible to get from exception.</returns>
            public static string GetExtendedExceptionDetails(object e, string indent = null)
            {
                // we want to be robust when dealing with errors logging
                try
                {
                    var sb = new StringBuilder(indent);
                    sb.AppendLine("NonSandboxedExceptionLogging");
                    // it's good to know the type of exception
                    sb.AppendLine($"Type: {e.GetType().FullName}");
                    // fetch instance level properties that we can read
                    var props = e.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
    
                    foreach (var p in props)
                    {
                        try
                        {
                            var v = p.GetValue(e, null);
    
                            // in case of Fault contracts we'd like to know what Detail contains
                            if (e is FaultException && p.Name == "Detail")
                            {
                                sb.AppendLine($"{indent}{p.Name}:");
                                sb.AppendLine(GetExtendedExceptionDetails(v, $"  {indent}"));// recursive call
                            }
                            // Usually this is InnerException
                            else if (v is Exception)
                            {
                                sb.AppendLine($"{indent}{p.Name}:");
                                sb.AppendLine(GetExtendedExceptionDetails(v as Exception, $"  {indent}"));// recursive call
                            }
                            // some other property
                            else
                            {
                                sb.AppendLine($"{indent}{p.Name}: '{v}'");
    
                                // Usually this is Data property
                                if (v is IDictionary)
                                {
                                    var d = v as IDictionary;
                                    sb.AppendLine($"{"  " + indent}Count={d.Count}");
                                    foreach (DictionaryEntry kvp in d)
                                    {
                                        sb.AppendLine($"{"  " + indent}[{kvp.Key}]:[{kvp.Value}]");
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            sb.AppendLine($"GetExtendedExceptionDetails: Exception during logging of property {p.Name}: {exception.Message}");
                        }
                    }
    
                    return sb.ToString();
                }
                catch (Exception exception)
                {
                    //log or swallow here
                    return $"GetExtendedExceptionDetails: Exception during logging of Exception message: {exception.Message}";
                }
            }
        }
    }
