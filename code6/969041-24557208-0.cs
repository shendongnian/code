    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using nsoftware.IPWorks;
    using myNamespace.ViewModel;
    
    namespace myNamespace
    {
        public partial class Chat : PhoneApplicationPage
        {
            private Xmpp xmpp1 = new Xmpp();
            private Xmpp xmpp2 = new Xmpp();
            private BindingChat bindingChat = new BindingChat();
    
            public Chat()
            {
                InitializeComponent();
                bindingChat.leftText = "jooooo2";
                xmpp1.OnConnected += new Xmpp.OnConnectedHandler(connect);
                ContentPanel.DataContext = bindingChat;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                xmpp1.IMServer = "***";
                xmpp1.IMPort = 5222;
                xmpp1.Connect("user1", "heslouser1");
                xmpp1.ChangePresence(1, "I'm here!");
            }
    
            private void connect(object sender, XmppConnectedEventArgs target)
            {
                DispatchInvoke(() =>
                {
                    bindingChat = new BindingChat();
                    bindingChat.leftText = "Connected";
                    ContentPanel.DataContext = bindingChat;
                }
            );
            }    
    
            public void DispatchInvoke(Action a)
            {
    
    #if SILVERLIGHT
                if (Dispatcher == null)
                    a();
                else
                    Dispatcher.BeginInvoke(a);
    #else
        if ((Dispatcher != null) && (!Dispatcher.HasThreadAccess))
        {
            Dispatcher.InvokeAsync(
                        Windows.UI.Core.CoreDispatcherPriority.Normal, 
                        (obj, invokedArgs) => { a(); }, 
                        this, 
                        null
             );
        }
        else
            a();
    #endif
            }
    
        }
    }
