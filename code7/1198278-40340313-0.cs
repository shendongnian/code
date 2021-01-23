    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using Microsoft.Win32;
    
    class Program
    {
        private static void Main(string[] args)
        {
            string fileName = @"E:\Pictures\Sample.jpg";
            string progId = AssocQueryString(AssocStr.ASSOCSTR_PROGID, fileName);
                 
            var verbs = GetVerbsByProgId(progId);
    
            if (!verbs.Contains("printto"))
            {
                throw new Exception("PrintTo is not supported!");
            }
    
        }
    
        private static string[] GetVerbsByProgId(string progId)
        {
            var verbs = new List<string>();
    
            if (!string.IsNullOrEmpty(progId))
            {
                using (var key = Registry.ClassesRoot.OpenSubKey(progId + "\\shell"))
                {
                    if (key != null)
                    {
                        var names = key.GetSubKeyNames();
                        verbs.AddRange(
                            names.Where(
                                name => 
                                    string.Compare(
                                        name, 
                                        "new", 
                                        StringComparison.OrdinalIgnoreCase) 
                                    != 0));
                    }
                }
            }
    
            return verbs.ToArray();
        }
    
        private static string AssocQueryString(AssocStr association, string extension)
        {
            uint length = 0;
            uint ret = AssocQueryString(
                AssocF.ASSOCF_NONE, association, extension, "printto", null, ref length);
            if (ret != 1) //expected S_FALSE
            {
                throw new Win32Exception();
            }
    
            var sb = new StringBuilder((int)length);
            ret = AssocQueryString(
                AssocF.ASSOCF_NONE, association, extension, null, sb, ref length);
            if (ret != 0) //expected S_OK
            {
                throw new Win32Exception();
            }
    
            return sb.ToString();
        }
    
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint AssocQueryString(
            AssocF flags,
            AssocStr str,
            string pszAssoc,
            string pszExtra,
            [Out] StringBuilder pszOut,
            ref uint pcchOut);
    
        [Flags]
        private enum AssocF : uint
        {
            ASSOCF_NONE = 0x00000000,
            ASSOCF_INIT_NOREMAPCLSID = 0x00000001,
            ASSOCF_INIT_BYEXENAME = 0x00000002,
            ASSOCF_OPEN_BYEXENAME = 0x00000002,
            ASSOCF_INIT_DEFAULTTOSTAR = 0x00000004,
            ASSOCF_INIT_DEFAULTTOFOLDER = 0x00000008,
            ASSOCF_NOUSERSETTINGS = 0x00000010,
            ASSOCF_NOTRUNCATE = 0x00000020,
            ASSOCF_VERIFY = 0x00000040,
            ASSOCF_REMAPRUNDLL = 0x00000080,
            ASSOCF_NOFIXUPS = 0x00000100,
            ASSOCF_IGNOREBASECLASS = 0x00000200,
            ASSOCF_INIT_IGNOREUNKNOWN = 0x00000400,
            ASSOCF_INIT_FIXED_PROGID = 0x00000800,
            ASSOCF_IS_PROTOCOL = 0x00001000,
            ASSOCF_INIT_FOR_FILE = 0x00002000
        }
    
        private enum AssocStr
        {
            ASSOCSTR_COMMAND = 1,
            ASSOCSTR_EXECUTABLE,
            ASSOCSTR_FRIENDLYDOCNAME,
            ASSOCSTR_FRIENDLYAPPNAME,
            ASSOCSTR_NOOPEN,
            ASSOCSTR_SHELLNEWVALUE,
            ASSOCSTR_DDECOMMAND,
            ASSOCSTR_DDEIFEXEC,
            ASSOCSTR_DDEAPPLICATION,
            ASSOCSTR_DDETOPIC,
            ASSOCSTR_INFOTIP,
            ASSOCSTR_QUICKTIP,
            ASSOCSTR_TILEINFO,
            ASSOCSTR_CONTENTTYPE,
            ASSOCSTR_DEFAULTICON,
            ASSOCSTR_SHELLEXTENSION,
            ASSOCSTR_DROPTARGET,
            ASSOCSTR_DELEGATEEXECUTE,
            ASSOCSTR_SUPPORTED_URI_PROTOCOLS,
            ASSOCSTR_PROGID,
            ASSOCSTR_APPID,
            ASSOCSTR_APPPUBLISHER,
            ASSOCSTR_APPICONREFERENCE,
            ASSOCSTR_MAX
        }
    }
