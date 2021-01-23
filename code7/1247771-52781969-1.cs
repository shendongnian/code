    ....
        LoginView m_lvStatus = (LoginView)Master.FindControl("lvStatus");
        LoginStatus m_logoutStatus =  (LoginStatus)m_lvStatus.FindControl("logoutStatus");
        m_logoutStatus.LoggingOut += new LoginCancelEventHandler(OnLoggingOut);
    }
    public void OnLoggingOut(object sender, LoginCancelEventArgs e)
    {
        SaveData();
    }
