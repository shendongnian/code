    // Onvif ODM
    using onvif.services;
    using odm.core;
    using onvif.utils;
    using utils;
    public string GetSnapshotUrl()
    {
      try
            {
                string camera_ip = "http://" + camIp + "/onvif/device_service";
                Uri Camuri = new Uri(camera_ip);
                NvtSessionFactory sessionFactory = new NvtSessionFactory(account);
                INvtSession session = sessionFactory.CreateSession(Camuri);
                Profile[] Profiles = session.GetProfiles().RunSynchronously();
                var snapshotlink = session.GetSnapshotUri(Profiles[0].token).RunSynchronously(); // taking snapshot on the first profile of the camera
                return snapshotlink.uri;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
