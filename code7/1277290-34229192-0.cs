    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    ...
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool CreateTimerQueueTimer(out IntPtr phNewTimer,
            IntPtr TimerQueue, WaitOrTimerDelegate Callback, IntPtr Parameter,
            uint DueTime, uint Period, uint Flags);
        [DllImport("kernel32.dll")]
        static extern bool ChangeTimerQueueTimer(IntPtr TimerQueue, IntPtr Timer,
            uint DueTime, uint Period);
        [DllImport("kernel32.dll")]
        static extern bool DeleteTimerQueueTimer(IntPtr TimerQueue, 
            IntPtr Timer, IntPtr CompletionEvent);
        public delegate void WaitOrTimerDelegate(IntPtr lpParameter, 
            bool TimerOrWaitFired);
    
        // Holds a reference to the function to be called when the timer
        // fires
        public static WaitOrTimerDelegate UpdateFn;
    
        public enum ExecuteFlags
        {
            /// <summary>
            /// The callback function is queued to an I/O worker thread. This flag should be used if the function should be executed in a thread that waits in an alertable state.
            /// The callback function is queued as an APC. Be sure to address reentrancy issues if the function performs an alertable wait operation.
            /// </summary>
            WT_EXECUTEINIOTHREAD = 0x00000001,
        };
    
        private Image gif;
        private int frameCount = -1;
        private UInt32[] frameIntervals;
        private int currentFrame = 0;
        private static object locker = new object();
        private IntPtr timerPtr;
    
        public Form1()
        {
            InitializeComponent();
            // Attempt to reduce flicker - all control painting must be
            // done in overridden paint methods
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            // Set the timer callback
            UpdateFn = new WaitOrTimerDelegate(UpdateFrame);
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // Replace this with whatever image you're animating
            gif = (Image)Properties.Resources.SomeAnimatedGif;
            // How many frames of animation are there in total?
            frameCount = gif.GetFrameCount(FrameDimension.Time);
            // Retrieve the frame time property
            PropertyItem propItem = gif.GetPropertyItem(20736);
            int propIndex = 0;
            frameIntervals = new UInt32[frameCount];
            // Each frame can have a different timing - retrieve each of them
            for (int i = 0; i < frameCount; i++)
            {
                // NB: intervals are given in hundredths of a second, so need
                // multiplying to match the timer's millisecond interval
                frameIntervals[i] = BitConverter.ToUInt32(propItem.Value, 
                    propIndex) * 10;
                // Point to the next interval stored in this property
                propIndex += 4;
            }
    
            // Show the first frame of the animation
            ShowFrame();
            // Start the animation. We use a TimerQueueTimer which has better
            // resolution than Windows Forms' default one. It should be used
            // instead of the multimedia timer, which has been deprecated
            CreateTimerQueueTimer(out this.timerPtr, IntPtr.Zero, UpdateFn, 
                IntPtr.Zero, frameIntervals[0], 100000,
                (uint)ExecuteFlags.WT_EXECUTEINIOTHREAD);
        }
    
        private void UpdateFrame(IntPtr lpParam, bool timerOrWaitFired)
        {
            // The timer has elapsed
            // Update the number of the frame to show next
            currentFrame = (currentFrame + 1) % frameCount;
            // Paint the frame to the panel
            ShowFrame();
            // Re-start the timer after updating its interval to that of
            // the new frame
            ChangeTimerQueueTimer(IntPtr.Zero, this.timerPtr,
                frameIntervals[currentFrame], 100000);
        }
    
        private void ShowFrame()
        {
            // We need to use a lock as we cannot update the GIF at the
            // same time as it's being drawn
            lock (locker)
            {
                gif.SelectActiveFrame(FrameDimension.Time, currentFrame);
            }
    
            this.panel1.Invalidate();
        }
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
    
            lock (locker)
            {
                e.Graphics.DrawImage(gif, panel1.ClientRectangle);
            }
        }
    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteTimerQueueTimer(IntPtr.Zero, timerPtr, IntPtr.Zero);
        }
    }
