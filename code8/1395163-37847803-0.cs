                    Dispatcher.Invoke(new Action(() =>
                   {
                       mainScrollViewer.ScrollToBottom();
                    }), DispatcherPriority.ContextIdle, null);
                }
            }
        }
