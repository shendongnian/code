     private void OnFunctionCalled(NktHook hook, NktProcess process, NktHookCallInfo hookCallInfo)
        {
            Output(hook.FunctionName + "( ");
            bool first = true;
            foreach (INktParam param in hookCallInfo.Params())
            {
                if (first)
                    first = false;
                else
                {
                    Output(", ");
                }
                Output(param.Name + " = " + param.Value.ToString());
            }
            Output(" )" + Environment.NewLine);
        }
