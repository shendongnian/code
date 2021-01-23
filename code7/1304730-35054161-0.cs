    public new event ContextMenuEventHandler ContextMenuOpening
            {
                add
                {
                    base.AddHandler(FrameworkElement.ContextMenuOpeningEvent, value);
                }
                remove
                {
                    base.RemoveHandler(FrameworkElement.ContextMenuOpeningEvent, value);
                }
            }
