    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows.Threading;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using ProgramOSMobile.Resources;
    
    namespace ProgramOSMobile
    {
        public partial class MainPage : PhoneApplicationPage
        {
    
            DispatcherTimer timer = new DispatcherTimer();
            int tick=0;
            public MainPage()
            {
                InitializeComponent();
    
                timer.Interval = TimeSpan.FromSeconds(0.5);
                timer.Start();
                timer.Tick += new EventHandler(splash);
            }
    
            private void splash(object sender, EventArgs e)
            {
                tick++;
                
                if(tick==5){
                    NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                }
            }
    
            
        }
    }
