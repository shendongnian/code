    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1 {
    [Flags]
    public enum IPD_Flags: uint {
        Normal = 0x00000000,
        Modal = 0x00000001,
        AutoTime = 0x00000002,
        NoTime = 0x00000004,
        NoMinimize = 0x00000008,
        NoProgressBar = 0x00000010 
    }
    [Flags]
    public enum IPDTIMER_Flags: uint {
        Reset = 0x00000001,
        Pause = 0x00000002,
        Resume = 0x00000003
    }
    [ComImport]
    [Guid("F8383852-FCD3-11d1-A6B9-006097DF5BD4")]
    internal class ProgressDialog {
    }
    [ComImport]
    [Guid("EBBC7C04-315E-11d2-B62F-006097DF5BD4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IProgressDialog {
        [PreserveSig]
        void StartProgressDialog(IntPtr hwndParent
            , [MarshalAs(UnmanagedType.IUnknown)] object  punkEnableModless
            , uint dwFlags
            , IntPtr pvResevered);
        [PreserveSig]
        void StopProgressDialog();
        [PreserveSig]
        void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pwzTitle);
        [PreserveSig]
        void SetAnimation(IntPtr hInstAnimation, ushort idAnimation);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool HasUserCancelled();
        [PreserveSig]
        void SetProgress(uint dwCompleted, uint dwTotal);
        [PreserveSig]
        void SetProgress64(ulong ullCompleted, ulong ullTotal );
        [PreserveSig]
        void SetLine(uint dwLineNum
            , [MarshalAs(UnmanagedType.LPWStr)] string pwzString
            , [MarshalAs(UnmanagedType.VariantBool)] bool fCompactPath
            , IntPtr pvResevered);
        [PreserveSig]
        void SetCancelMsg([MarshalAs(UnmanagedType.LPWStr)]string pwzCancelMsg, object pvResevered);
        [PreserveSig]
        void Timer(uint dwTimerAction, object pvResevered);
    }
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            ProgressDialog progressDialog = new ProgressDialog();
            IProgressDialog iProgressDialog = (IProgressDialog)progressDialog;
            iProgressDialog.Timer((uint) IPDTIMER_Flags.Resume, null);
            iProgressDialog.StartProgressDialog(this.Handle
                , null
                , (uint)(IPD_Flags.Normal | IPD_Flags.NoMinimize)
                , IntPtr.Zero);
        }
    }
}
