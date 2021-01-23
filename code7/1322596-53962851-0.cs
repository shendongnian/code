    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    namespace System.Windows.Forms
    {
      [ToolboxBitmap(typeof(Form))]
      public class ProgressForm : Form
      {
        private ThumbnailProgressState m_State = ThumbnailProgressState.NoProgress;
        private int m_Maximum = 100;
        private int m_Value = 0;
        //
        // Summary:
        //     Gets or sets the state in which progress should be indicated on the task
        //     bar.
        //
        // Returns:
        //     One of the System.Windows.Forms.ThumbnailProgressState values. The default is System.Windows.Forms.ThumbnailProgressState.NoProgress
        //
        // Exceptions:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     The value is not a member of the System.Windows.Forms.ThumbnailProgressState enumeration.
        [Browsable(true)]
        [DefaultValue(ThumbnailProgressState.NoProgress)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public ThumbnailProgressState State
        {
          get { return m_State; }
          set
          {
            switch (value)
            {
              case ThumbnailProgressState.NoProgress:
              case ThumbnailProgressState.Indeterminate:
              case ThumbnailProgressState.Normal:
              case ThumbnailProgressState.Error:
              case ThumbnailProgressState.Paused:
                m_State = value;
                OnStateChanged(new EventArgs());
                break;
              default:
                throw new InvalidEnumArgumentException("The value is not a member of the System.Windows.Forms.ThumbnailProgressState enumeration.");
            }
          }
        }
        //
        // Summary:
        //     Gets or sets the current position of the progress bar.
        //
        // Returns:
        //     The position within the range of the progress bar. The default is 0.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The value specified is greater than the value of the System.Windows.Forms.ProgressForm.Maximum
        //     property. -or- The value specified is less than 0.
        [Browsable(true)]
        [DefaultValue(0)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int Value
        {
          get { return m_Value; }
          set
          {
            if ((value < 0) || (value > m_Maximum))
            {
              throw new ArgumentException("The value specified is greater than the value of the System.Windows.Forms.ProgressForm.Maximum property. -or- The value specified is less than 0.");
            }
            else
            {
              m_Value = value;
              OnValueChanged(new EventArgs());
            }
          }
        }
        //
        // Summary:
        //     Gets or sets the maximum value of the range of the control.
        //
        // Returns:
        //     The maximum value of the range. The default is 100.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The value specified is less than 0.
        [Browsable(true)]
        [DefaultValue(100)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int Maximum
        {
          get { return m_Maximum; }
          set
          {
            if (value < 0) 
            {
              throw new ArgumentException("The value specified is less than 0.");
            }
            else
            {
              m_Maximum = value;
              if (value < m_Value) m_Value = value;
              OnMaximumChanged(new EventArgs());
            }
          }
        }
        protected virtual void OnStateChanged(EventArgs e)
        {
          if (Windows7orGreater) SetProgressState();
        }
        protected virtual void OnValueChanged(EventArgs e)
        {
          if (Windows7orGreater) SetProgressValue();
        }
        protected virtual void OnMaximumChanged(EventArgs e)
        {
          if (Windows7orGreater) SetProgressValue();
        }
        protected override void WndProc(ref Message m)
        {
          if (Windows7orGreater)
          {
            // if taskbar button created or recreated, update progress status
            if (m.Msg == WM_TaskbarButtonCreated) SetProgressState();
          }
          base.WndProc(ref m);
        }
        private void SetProgressState()
        {
          // must be Windows7orGreater
          TaskbarList.SetProgressState(Handle, m_State);
          SetProgressValue();
        }
        private void SetProgressValue()
        {
          // must be Windows7orGreater
          switch (m_State)
          {
            case ThumbnailProgressState.Normal:
            case ThumbnailProgressState.Error:
            case ThumbnailProgressState.Paused:
              TaskbarList.SetProgressValue(Handle, (ulong)m_Value, (ulong)m_Maximum);
              break;
          }
        }
        private static int WM_TaskbarButtonCreated = -1;
        private static int _winVersion = -1;
        internal static bool Windows7orGreater
        {
          get
          {
            if (_winVersion < 0)
            {
              Version osVersion = Environment.OSVersion.Version;
              if ((osVersion.Major == 6 && osVersion.Minor > 0) || (osVersion.Major > 6))
              {
                // Taskbar progress indicator requires Windows 7 Or Greater
                _winVersion = 1;
                // register taskbar creation window message
                WM_TaskbarButtonCreated = RegisterWindowMessage(@"TaskbarButtonCreated");
              }
              else
              {
                _winVersion = 0;
              }
            }
            return (_winVersion > 0);
          }
        }
        private static ITaskbarList3 _taskbarList = null;
        internal static ITaskbarList3 TaskbarList
        {
          get
          {
            if (_taskbarList == null)
            {
              lock (typeof(ProgressForm))
              {
                if (_taskbarList == null)
                {
                  _taskbarList = (ITaskbarList3)new CTaskbarList();
                  _taskbarList.HrInit();
                }
              }
            }
            return _taskbarList;
          }
        }
        [DllImport("user32.dll")]
        internal static extern int RegisterWindowMessage(string message);
        [ComImportAttribute()]
        [GuidAttribute("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ITaskbarList3
        {
          // ITaskbarList
          [PreserveSig]
          void HrInit();
          [PreserveSig]
          void AddTab(IntPtr hwnd);
          [PreserveSig]
          void DeleteTab(IntPtr hwnd);
          [PreserveSig]
          void ActivateTab(IntPtr hwnd);
          [PreserveSig]
          void SetActiveAlt(IntPtr hwnd);
          // ITaskbarList2
          [PreserveSig]
          void MarkFullscreenWindow(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
          // ITaskbarList3
          void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
          void SetProgressState(IntPtr hwnd, ThumbnailProgressState tbpFlags);
        }
        [GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterfaceAttribute(ClassInterfaceType.None)]
        [ComImportAttribute()]
        internal class CTaskbarList { }
      }
      public enum ThumbnailProgressState
      {
        /// <summary>
        /// No progress is displayed.
        /// </summary>
        NoProgress = 0,
        /// <summary>
        /// The progress is indeterminate (marquee).
        /// </summary>
        Indeterminate = 0x1,
        /// <summary>
        /// Normal progress is displayed.
        /// </summary>
        Normal = 0x2,
        /// <summary>
        /// An error occurred (red).
        /// </summary>
        Error = 0x4,
        /// <summary>
        /// The operation is paused (yellow).
        /// </summary>
        Paused = 0x8
      }
    }
