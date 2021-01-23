    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace CreateFormWindowSO
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var windowId = "Some window";
                CreateWindow(windowId, 320, 240, "My Window");
                // Put a breakpoint on the line below and step over it with the debugger.
                // You'll see it returns the correct form object that was created above.
                var someWindow = GetWindow(windowId);
                // Do something with 'someWindow'.
            }
            static Form GetWindow(string id)
            {
                return windows[id];
            }
            static void CreateWindow(string id, int width, int height, string title)
            {
                Form form = new Form();
                form.Text = title;
                form.Size = new Size(width, height);
                windows.Add(id, form);
            }
            static Dictionary<string, Form> windows = new Dictionary<string, Form>();
        }
    }
