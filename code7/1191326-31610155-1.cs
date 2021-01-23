    //int expectedSize = Marshal.SizeOf(typeof(Wlan.WlanReasonCode));
                                if (notifyData.dataSize >= 0)
                                {
                                    Wlan.WlanReasonCode reasonCode = (Wlan.WlanReasonCode)Marshal.ReadInt32(notifyData.dataPtr);
                                    if (wlanIface != null)
                                        wlanIface.OnWlanReason(notifyData, reasonCode);
                                }
