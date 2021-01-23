    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace ComExportTester
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Load += (o1, e) => Close();
                Type t;
                object o;
                ComExport.ComClass1Interface i1;
                string s = "";
                try
                {
                    t = Type.GetTypeFromCLSID(new Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938"));
                    s += "Type found \t: " + (t == null ? "no" : "yes") + "\n";
                    o = t == null ? null : Activator.CreateInstance(t);
                    s += "object created \t: " + (o == null ? "no" : o.ToString()) + "\n";
                    i1 = o as ComExport.ComClass1Interface;
                    s += "interface cast \t: " + (i1 == null ? "no" : "yes") + "\n";
                    if (i1 != null)
                        s += i1.DoCall() + "\n";
                }
                catch (Exception x)
                {
                    s += x.Message + "\n";
                }
                MessageBox.Show(s);
            }
        }
    }
    namespace ComExport
    {
        [ComImport]
        [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeIdentifier()]
        public interface ComClass1Interface
        {
            string DoCall();
        }
    }
