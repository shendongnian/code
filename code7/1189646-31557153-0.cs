    private Task DoWorkInOtherDomain(PluginProxy pProxy, PluginPanel panel, string user)
        {
            var ch = new MarshaledResultSetter<string>();
            pProxy.Execute(panel, user, ch);
            return ch.Task;
        }
