    using System;
    using SteamKit2;
    using System.Collections.Generic;
    namespace StackOverflow
    {
        class SteamBot
        {
            CallbackManager             m_CallbackManager;
            SteamUser                   m_SteamUser;
            SteamClient                 m_SteamClient;
            SteamFriends                m_SteamFriends;
            SteamID                     m_SteamID;
            Dictionary<string, string>  m_Config;
            public bool isLoggedOn { get; private set; }
            public bool isReady { get; private set; }
            public SteamBot(string pUsername, string pPassword)
            {
                isLoggedOn = false;
                isReady = false;
                m_Config = new Dictionary<string, string>();
                m_Config.Add("username", pUsername);
                m_Config.Add("password", pPassword);
                Init();
                RegisterCallbacks();
                Connect();            
            }
            private void Init()
            {
                m_SteamClient = new SteamClient();
                m_CallbackManager = new CallbackManager(m_SteamClient);
                m_SteamFriends = m_SteamClient.GetHandler<SteamFriends>();
                m_SteamUser = m_SteamClient.GetHandler<SteamUser>();
            }
       
            private void RegisterCallbacks()
            {
                m_CallbackManager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
                m_CallbackManager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
                m_CallbackManager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
                m_CallbackManager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);
                m_CallbackManager.Subscribe<SteamUser.AccountInfoCallback>(OnAccountInfo);
            }
            public void WaitForCallbacks()
            {
                m_CallbackManager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
            public string GetConfigValue(string pKey)
            {
                return m_Config[pKey];
            }
            public void Connect()
            {
                m_SteamClient.Connect();
                isReady = true;
            }
            void OnConnected(SteamClient.ConnectedCallback pData)
            {
                Console.WriteLine("Connected to Steam! Logging in '{0}'...", GetConfigValue("username"));
                SteamUser.LogOnDetails details = new SteamUser.LogOnDetails
                {
                    Username = GetConfigValue("username"),
                    Password = GetConfigValue("password"),
                };
                m_SteamUser.LogOn(details);
                m_SteamID = m_SteamClient.SteamID;
            }
            void OnDisconnected(SteamClient.DisconnectedCallback pData)
            {
                m_SteamClient.Disconnect();
            }
            void OnLoggedOff(SteamUser.LoggedOffCallback pData)
            {
                isLoggedOn = false;
            }
            void OnLoggedOn(SteamUser.LoggedOnCallback pData)
            {
                if (pData.Result != EResult.OK)
                {
                    Console.WriteLine("Unable to login to Steam: {0} / {1}", pData.Result, pData.ExtendedResult);
                    return;
                }
                Console.WriteLine("Successfully logged on!");
                isLoggedOn = true;
            }
            void OnAccountInfo(SteamUser.AccountInfoCallback pData)
            {
                //Announce to all friends that we are online
                m_SteamFriends.SetPersonaState(EPersonaState.Online);
            }
        }
    }
