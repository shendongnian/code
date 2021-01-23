    namespace StackOverflow.DoubleClickExample
    {
        using System;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
        using System.Threading.Tasks;
        using System.Windows;
        using System.Windows.Input;
        public partial class MainWindow : Window
        {
            [DllImport("user32.dll")]
            public static extern uint GetDoubleClickTime();
            public MainWindow()
            {
                this.InitializeComponent();
            }
            private Guid lastGuid = Guid.Empty;
            private void RootElement_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ClickCount == 1)
                {
                    // Create new unique id and save it into field.
                    var guid = Guid.NewGuid();
                    this.lastGuid = guid;
                    // Run task asynchronously for ensuring that there is no another click
                    // happened in time interval when double-click can occure.
                    Task.Run(async () =>
                    {
                        // Wait system double-click time interval.
                        await Task.Delay((int)GetDoubleClickTime());
                        // If no double-click occured in awaited time interval, then
                        // last saved id (saved when first click occured) will be unchanged.
                        if (guid == this.lastGuid)
                        {
                            // Here is any logic for single-click handling.
                            Trace.WriteLine("Single-click occured");
                        }
                    });
                    return;
                }
                // Can be here only when e.ClickCount > 1, so must change last saved unique id.
                // After that, asynchronously running task (for single-click) will detect
                // that id was changed and so will NOT run single-click logic.
                this.lastGuid = Guid.NewGuid();
                // Here is any logic for double-click handling.
                Trace.WriteLine("Double-click occured");
            }
        }
    }
