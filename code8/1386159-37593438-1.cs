    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using Outlook = Microsoft.Office.Interop.Outlook;
    namespace Data.OutlookHelper
    {
        public class AdxCalendar
        {
            public static Outlook.MAPIFolder getCallendar(Outlook.Application OutlookApp, string path)
            {
                Outlook.MAPIFolder calendar = null;
                foreach (Outlook.Store store in OutlookApp.Session.Stores)
                {
                    if (store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).FullFolderPath.Equals(path))
                    {
                        calendar = store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
                        break;
                    }
                    foreach (Outlook.MAPIFolder folder in store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders)
                    {
                        if (folder.FullFolderPath.Equals(path))
                        {
                            calendar = folder;
                            break;
                        }
                    }
                    if (calendar != null)
                        break;
                }
                if (calendar == null)
                {
                    return null;
                }
                return calendar;
            }
        }
    }
