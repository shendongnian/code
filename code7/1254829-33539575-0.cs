        /// <summary>
        ///  ("Connection Type", `0`-`3`): `0` - cellular, `1` - wifi / ethernet, `2` - inne;
        /// </summary>
        /// <returns></returns>
        public byte GetConnectionGeneration()
        {
            try
            {
                ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
                if (profile.IsWwanConnectionProfile)
                {
                    WwanDataClass connectionClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
                    switch (connectionClass)
                    {
                        //2G-equivalent
                        case WwanDataClass.Edge:
                        case WwanDataClass.Gprs:
                        //3G-equivalent
                        case WwanDataClass.Cdma1xEvdo:
                        case WwanDataClass.Cdma1xEvdoRevA:
                        case WwanDataClass.Cdma1xEvdoRevB:
                        case WwanDataClass.Cdma1xEvdv:
                        case WwanDataClass.Cdma1xRtt:
                        case WwanDataClass.Cdma3xRtt:
                        case WwanDataClass.CdmaUmb:
                        case WwanDataClass.Umts:
                        case WwanDataClass.Hsdpa:
                        case WwanDataClass.Hsupa:
                        //4G-equivalent
                        case WwanDataClass.LteAdvanced:
                            return 0;
                        //not connected
                        case WwanDataClass.None:
                            return 2;
                        //unknown
                        case WwanDataClass.Custom:
                        default:
                            return 2;
                    }
                }
                else if (profile.IsWlanConnectionProfile)
                {
                    return 1;
                }
                return 2;
            }
            catch (Exception)
            {
                return 2; //as default
            }
           
        }
