    using System;
    using Caliburn.Micro;
    using System.Windows.Media;
    using System.Windows;
    
    namespace ChangingMahAppsIcon
    {
        class CHeartbeatViewModel : PropertyChangedBase
        {
            public Visual IconResource { get; set; }
    
            private System.Timers.Timer m_oHeartbeatTimer;
            private ResourceDictionary m_oIconResource;
            private bool m_bHeartbeatIsOn = false;
    
            public CHeartbeatViewModel()
            {
                m_oIconResource = new ResourceDictionary() { Source = new Uri(@"Resources\Icons.xaml", UriKind.Relative) };
    
                m_oHeartbeatTimer = new System.Timers.Timer(1000);
                m_oHeartbeatTimer.Elapsed += UpdateHeartbeat;
    
                m_oHeartbeatTimer.Start();
                
            }
    
            private void UpdateHeartbeat(object sender, System.Timers.ElapsedEventArgs e)
            {
                string strIconName;
                m_bHeartbeatIsOn = !m_bHeartbeatIsOn;
                if (m_bHeartbeatIsOn)
                {
                    strIconName = "appbar_heart";
                }
                else
                {
                    strIconName = "appbar_heart_outline";
                }
    
                Application.Current.Dispatcher.Invoke((System.Action)delegate {
    
                    IconResource = (Visual)m_oIconResource[strIconName];
                    NotifyOfPropertyChange(() => IconResource);
                });
    
            }
        }
    }
