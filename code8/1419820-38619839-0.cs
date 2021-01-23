    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Xml;
    // Courteously curated and posted to Stack Overflow by S Meaden from MSDN samples and documentation
    namespace RotViewerScriptable
    {
        internal static class RotNativeMethods
        {
            [DllImport("ole32.dll", PreserveSig = false)]
            internal static extern void CreateBindCtx(uint reserved, out IBindCtx ppbc);
            [DllImport("ole32.dll")]
            internal static extern int GetRunningObjectTable(int reserved,
                out IRunningObjectTable prot);
            [DllImport("ole32.dll")]
            internal static extern int CreateFileMoniker([MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, out System.Runtime.InteropServices.ComTypes.IMoniker ppmk);
            [DllImport("oleaut32.dll")]
            internal static extern int RevokeActiveObject(int register, IntPtr reserved);
            [DllImport("kernel32.dll")]
            internal static extern bool FileTimeToLocalFileTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime,
               out System.Runtime.InteropServices.ComTypes.FILETIME lpLocalFileTime);
            [DllImport("ole32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
            [return: MarshalAs(UnmanagedType.LPWStr)]
            internal static extern string StringFromCLSID([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid);
            [DllImport("ole32.dll")]
            internal static extern int IIDFromString([MarshalAs(UnmanagedType.LPWStr)] string lpsz,
               out Guid lpiid);
        }
        public interface IMonikerDetails
        {
            string monikerType { get; set; }
            string monikerClassId { get; set; }
        }
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(IMonikerDetails))]
        public class MonikerDetails : IMonikerDetails
        {
            public string monikerType { get; set; }
            public string monikerClassId { get; set; }
        }
        /// <summary>
        /// We have to make this a class instead of a struct so VBA can script against it
        /// </summary>
        public interface IRotTableEntry
        {
            string displayName { get; set; }
            DateTime lastChange { get; set; }
            string className { get; set; }
            MonikerDetails monikerDetails { get; set; }
        }
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(IRotTableEntry))]
        public class RotTableEntry : IRotTableEntry
        {
            public string displayName { get; set; }
            public DateTime lastChange { get; set; }
            public string className { get; set; }
            public MonikerDetails monikerDetails { get; set; }
        }
        /// <summary>
        /// Be a good COM citizen and define the interface separately.
        /// In AssemblyInfo.cs we have [assembly: ComVisible(true)].
        /// In Project Properties->Build tab under the Output section we have checked the 'Register for COM interop' checkbox.
        /// </summary>
        public interface IRotViewer
        {
            RotTableEntry[] DetailedTableAsArray();
            string DetailedTableAsXml();
            string DetailedTableAsJson();
            string[] TableAsStringArray();
            string TableAsXml();
            string TableAsJson();
            object GetObject(string sRotEntry);
            bool IsExcelFileName(string filename);
            int[] RegisterObject(object obj, string stringId);
            int RevokeActiveObject(int register);
        }
        /// <summary>
        /// A single class that reads the Running Object Table and is instantiable/creatable from VBA, JScript and scripting clients.
        /// </summary>
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(IRotViewer))]
        public class RotViewer : IRotViewer
        {
            /// <summary>
            /// This is the equivalent of VBA's GetObject where one supplies a filename or other moniker to retrieve an interface pointer to object.
            /// </summary>
            /// <param name="sRotEntry"></param>
            /// <returns>A COM interface pointer to object in running object table specified by entry.</returns>
            public object GetObject(string sRotEntry)
            {
                Object retVal = null;
                IBindCtx ctx;
                IRunningObjectTable table;
                IEnumMoniker mon;
                IMoniker[] lst = new IMoniker[1];
                RotNativeMethods.CreateBindCtx(0, out ctx);
                ctx.GetRunningObjectTable(out table);
                table.EnumRunning(out mon);
                while (mon.Next(1, lst, IntPtr.Zero) == 0)
                {
                    string displayName;
                    lst[0].GetDisplayName(ctx, lst[0], out displayName);
                    if (displayName == sRotEntry)
                    {
                        table.GetObject(lst[0], out retVal);
                    }
                }
                return retVal;
            }
            /// <summary>
            /// For VBA Clients we can use COM interop compatible types to return table as string array.
            /// </summary>
            /// <returns>An string array of all the entries in the Running Object Table.</returns>
            public string[] TableAsStringArray()
            {
                List<string> itemsList = new List<string>();
                IBindCtx ctx;
                IRunningObjectTable table;
                IEnumMoniker mon;
                IMoniker[] lst = new IMoniker[1];
                RotNativeMethods.CreateBindCtx(0, out ctx);
                ctx.GetRunningObjectTable(out table);
                table.EnumRunning(out mon);
                while (mon.Next(1, lst, IntPtr.Zero) == 0)
                {
                    string displayName;
                    lst[0].GetDisplayName(ctx, lst[0], out displayName);
                    itemsList.Add(displayName);
                }
                return itemsList.ToArray();
            }
            /// <summary>
            /// For clients that prefer to work with Xml documents call this.
            /// </summary>
            /// <returns>An Xml string of a document of all the entries in the Running Object Table.</returns>
            public string TableAsXml()
            {
                string[] table = this.TableAsStringArray();
                XmlDocument dom = new XmlDocument();
                dom.LoadXml("<RotTable/>");
                foreach (string s in table)
                {
                    XmlElement rte = dom.CreateElement("RotTableEntry");
                    rte.InnerText = s;
                    dom.DocumentElement.AppendChild(rte);
                }
                return dom.OuterXml;
            }
            /// <summary>
            /// Call this from Javascript and then use JSON.parse() to get the entries as an array.
            /// </summary>
            /// <returns>A JSON string of all the entries in the Running Object Table.</returns>
            public string TableAsJson()
            {
                string[] table = this.TableAsStringArray();
                string json = "";
                foreach (string s in table)
                {
                    string text = s.Replace(@"\", @"\\");
                    if (json.Length > 0) { json = json + ","; }
                    json = json + "\"" + text + "\"";
                }
                return "[" + json + "]";
            }
            /// <summary>
            /// Utility method to help clients filter items.
            /// </summary>
            /// <param name="filename">An entry for the Running Object Table.</param>
            /// <returns>True if it is an Excel file.</returns>
            public bool IsExcelFileName(string filename)
            {
                string extension = Path.GetExtension(filename).ToUpper();
                return (extension == ".XLS" || extension == ".XLSX" || extension == ".XLSM");
            }
            /// <summary>
            /// This allows us to register an object in the Running Object Table
            /// </summary>
            /// <param name="obj">A Com interface pointer owned by the object</param>
            /// <param name="stringId">A display name for the object</param>
            /// <returns>Returns two integers as an array, the first is the HRESULT of system calls and if successful the second is the registration id (regid).  You'll need the regid to revoke from the ROT when tidying up.</returns>
            public int[] RegisterObject(object obj, string stringId)
            {
                int[] retval = new int[] { 0, 0 };
                int regId = -1;
                System.Runtime.InteropServices.ComTypes.IRunningObjectTable pROT = null;
                System.Runtime.InteropServices.ComTypes.IMoniker pMoniker = null;
                int hr;
                if ((hr = RotNativeMethods.GetRunningObjectTable((int)0, out pROT)) != 0)
                {
                    retval[0] = hr;
                    return retval; //(hr);
                }
                // File Moniker has to be used because in VBS GetObject only works with file monikers in the ROT
                if ((hr = RotNativeMethods.CreateFileMoniker(stringId, out pMoniker)) != 0)
                {
                    retval[0] = hr;
                    return retval; //(hr);
                }
                int ROTFLAGS_REGISTRATIONKEEPSALIVE = 1;
                regId = pROT.Register(ROTFLAGS_REGISTRATIONKEEPSALIVE, obj, pMoniker);
                retval[0] = 0;
                retval[1] = regId;
                return retval;
            }
            /// <summary>
            /// Removes an object previously registered with RegisterObject(,).
            /// </summary>
            /// <param name="register">The registration id (regid) returned from RegisterObject().</param>
            /// <returns></returns>
            public int RevokeActiveObject(int register)
            {
                int hr;
                hr = RotNativeMethods.RevokeActiveObject(register, IntPtr.Zero);
                return hr;
            }
            public RotTableEntry[] DetailedTableAsArray()
            {
                List<RotTableEntry> itemsList = new List<RotTableEntry>();
                IBindCtx ctx;
                IRunningObjectTable table;
                IEnumMoniker mon;
                IMoniker[] lst = new IMoniker[1];
                RotNativeMethods.CreateBindCtx(0, out ctx);
                ctx.GetRunningObjectTable(out table);
                table.EnumRunning(out mon);
                while (mon.Next(1, lst, IntPtr.Zero) == 0)
                {
                    RotTableEntry item = new RotTableEntry();
                    item.monikerDetails = new MonikerDetails();
                    {
                        Guid guid;
                        lst[0].GetClassID(out guid);
                        item.monikerDetails.monikerClassId = RotNativeMethods.StringFromCLSID(guid);
                        switch (item.monikerDetails.monikerClassId)
                        {
                            case "{00000303-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "FileMoniker";
                                break;
                            case "{00000304-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "ItemMoniker";
                                break;
                            case "{00000305-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "AntiMoniker";
                                break;
                            case "{00000306-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "PointerMoniker";
                                break;
                            case "{00000308-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "PackageMoniker";
                                break;
                            case "{00000309-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "CompositeMoniker";
                                break;
                            case "{0000031A-0000-0000-C000-000000000046}":
                                item.monikerDetails.monikerType = "ClassMoniker";
                                break;
                            default:
                                {
                                    RegistryKey monikerClassKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + item.monikerDetails.monikerClassId);
                                    if (monikerClassKey == null)
                                    {
                                        item.monikerDetails.monikerType = "Failed to identify moniker";
                                    }
                                    else
                                    {
                                        item.monikerDetails.monikerType = monikerClassKey.GetValue(null).ToString();
                                    }
                                }
                                break;
                        }
                    }
                    {
                        string displayName;
                        lst[0].GetDisplayName(ctx, lst[0], out displayName);
                        item.displayName = displayName;
                        item.className = "";
                    }
                    {
                        if (item.monikerDetails.monikerType == "FileMoniker")
                        {
                            System.Runtime.InteropServices.ComTypes.FILETIME ft;
                            table.GetTimeOfLastChange(lst[0], out ft);
                            long hFT2 = (((long)ft.dwHighDateTime) << 32) + ft.dwLowDateTime;
                            DateTime dte = DateTime.FromFileTime(hFT2);
                            item.lastChange = dte;
                            //http://snipplr.com/view/32409/
                        }
                        if (item.monikerDetails.monikerType == "ItemMoniker")
                        {
                            string coreGuid = "";
                            {
                                if (item.displayName.Substring(0, 1) == "!")
                                {
                                    coreGuid = item.displayName.Substring(1, 38);
                                    RegistryKey key = null;
                                    key = Registry.ClassesRoot.OpenSubKey("CLSID\\" + coreGuid);
                                    if (key == null)
                                    {
                                        key = Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID\\" + coreGuid);
                                    }
                                    if (key != null)
                                    {
                                        item.className = key.GetValue(null).ToString();
                                    }
                                }
                            }
                        }
                    }
                    itemsList.Add(item);
                }
                return itemsList.ToArray();
            }
            /// <summary>
            /// For clients that prefer to work with Xml documents call this.
            /// </summary>
            /// <returns>An Xml string of a document of all the detailed entries in the Running Object Table.</returns>
            public string DetailedTableAsXml()
            {
                RotTableEntry[] table = this.DetailedTableAsArray();
                XmlDocument dom = new XmlDocument();
                dom.LoadXml("<RotTable/>");
                foreach (RotTableEntry tb in table)
                {
                    XmlElement rte = dom.CreateElement("RotTableEntry");
                    XmlElement dn = dom.CreateElement("DisplayName");
                    dn.InnerText = tb.displayName;
                    rte.AppendChild(dn);
                    XmlElement lcd = dom.CreateElement("LastChange");
                    DateTime.UtcNow.ToString("o");
                    lcd.InnerText = tb.lastChange.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
                    rte.AppendChild(lcd);
                    XmlElement monType = dom.CreateElement("MonikerType");
                    monType.InnerText = tb.monikerDetails.monikerType;
                    rte.AppendChild(monType);
                    XmlElement clsNam = dom.CreateElement("ClassName");
                    clsNam.InnerText = tb.className;
                    rte.AppendChild(clsNam);
                    dom.DocumentElement.AppendChild(rte);
                }
                return dom.OuterXml;
            }
            public string DetailedTableAsJson()
            {
                RotTableEntry[] table = this.DetailedTableAsArray();
                string wholeJson = "";
                foreach (RotTableEntry tbe in table)
                {
                    string jsonTE = "";
                    {
                        string displayNameString = tbe.displayName.Replace(@"\", @"\\");
                        jsonTE = jsonTE + "\"displayName\":\"" + displayNameString + "\",";
                    }
                    string jsonTEMonDetails = "";
                    {
                        jsonTEMonDetails = jsonTEMonDetails + "\"monikerType\":\"" + tbe.monikerDetails.monikerType + "\",";
                        jsonTEMonDetails = jsonTEMonDetails + "\"monikerClassId\":\"" + tbe.monikerDetails.monikerClassId + "\"";
                        jsonTEMonDetails = "{" + jsonTEMonDetails + "}";
                        jsonTE = jsonTE + "\"monikerDetails\":" + jsonTEMonDetails + "";
                    }
                    {
                        if (tbe.lastChange != DateTime.MinValue)
                        {
                            string lastChangeString = tbe.lastChange.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
                            jsonTE = jsonTE + ",\"lastChange\":\"" + lastChangeString + "\"";
                        } else
                        {
                            jsonTE = jsonTE + ",\"lastChange\":\"\"";
                        }
                    }
                    {
                        jsonTE = jsonTE + ",\"className\":\"" + tbe.className + "\"";
                    }
                    jsonTE = "{" + jsonTE + "}";
                    if (wholeJson.Length > 0) { wholeJson = wholeJson + ","; }
                    wholeJson = wholeJson + jsonTE;
                }
                return "[" + wholeJson + "]";
            }
        }
    }
