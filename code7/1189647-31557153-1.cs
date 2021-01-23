     public void Execute(PluginPanel panel, string user, MarshaledResultSetter<string> ch)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                m_Plugin.Execute(panel, user);
                ch.SetResult(AppDomain.CurrentDomain.FriendlyName);
            });
        }
