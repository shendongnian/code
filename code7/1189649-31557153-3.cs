     Task.Run(() =>
            {
                try
                {
                    m_Plugin.Execute(panel, user).Wait();
                }
                catch (AggregateException e)
                {
                    if (e.InnerExceptions != null)
                        foreach (Exception ein in e.InnerExceptions)
                            AddToErrorLog(panel.PanelName, ein);
                }
                catch (Exception e) { AddToErrorLog(panel.PanelName, e); }
                finally { ch.SetResult(AppDomain.CurrentDomain.FriendlyName); }
            });
