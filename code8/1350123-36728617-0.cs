    using System;
    using System.Drawing;
    using System.Windows.Controls;
    
    namespace MyApp
    {
        class NotifyIconEx
        {
            #region Data
            private System.Windows.Forms.NotifyIcon _notifyIcon = new System.Windows.Forms.NotifyIcon();
            #endregion // Data
    
            #region Properties
            public Icon Icon
            {
                get { return _notifyIcon.Icon; }
                set { _notifyIcon.Icon = value; }
            }
            public ContextMenu ContextMenu
            {
                private get { return null; }
                set
                {
                    _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                    foreach (var item in value.Items)
                    {
                        if (item is MenuItem)
                        {
                            var menuItem = item as MenuItem;
                            var toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                            toolStripMenuItem.Click += (s, e) => menuItem.RaiseEvent(new System.Windows.RoutedEventArgs(MenuItem.ClickEvent));
                            toolStripMenuItem.Text = menuItem.Header as string;
                            _notifyIcon.ContextMenuStrip.Items.Add(toolStripMenuItem);
                        }
                        else if (item is Separator)
                        {
                            _notifyIcon.ContextMenuStrip.Items.Add(new System.Windows.Forms.ToolStripSeparator());
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
            }
            public bool Visible
            {
                get { return _notifyIcon.Visible; }
                set { _notifyIcon.Visible = value; }
            }
            #endregion // Properties
    
            #region API
            public void ShowBalloonTip(int timeout)
            {
                _notifyIcon.ShowBalloonTip(timeout);
            }
            public void ShowBalloonTip(int timeout, string tipTitle, string tipText, System.Windows.Forms.ToolTipIcon tipIcon)
            {
                _notifyIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
            }
            #endregion // API
        }
    }
