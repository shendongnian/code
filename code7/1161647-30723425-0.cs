    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace ActiveXControl
    {
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("2F76566A-964F-4547-BD48-EE498AE1A7A2")]
        [ProgId("ActiveXControl.ControlClass")]
        [ComDefaultInterface(typeof(Intermediate))]
        public partial class ControlClass : UserControl, Intermediate, IObjectSafety
        {
            public ControlClass()
            {
                InitializeComponent();
            }
            public string UserTxt { get; set; }
            public string password { get; set; }
    
            public void getmethod()
            {
                textBox1.Text = UserTxt;
                textBox2.Text = password;
            }
            public string Data()
            {
                return textBox1.Text +" " + textBox2.Text;
            }
            public enum ObjectSafetyOptions
            {
                INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001,
                INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002,
                INTERFACE_USES_DISPEX = 0x00000004,
                INTERFACE_USES_SECURITY_MANAGER = 0x00000008
            };
    
            public int GetInterfaceSafetyOptions(ref Guid riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
            {
                ObjectSafetyOptions m_options = ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_CALLER | ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_DATA;
                pdwSupportedOptions = (int)m_options;
                pdwEnabledOptions = (int)m_options;
                return 0;
            }
    
            public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
            {
                return 0;
            }
        }
    }
