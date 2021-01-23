    onvif.utils.OdmSession odmSession = new onvif.utils.OdmSession(session);
    odmSession.GetPullPointEvents().Subscribe(
        onvifEvent =>
        {
            try
            {
                foreach (var s in onvifEvent.message.Data.simpleItem)
                {
                    if (s.name == "LogicalState")
                    {
                        // code here
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
    });
