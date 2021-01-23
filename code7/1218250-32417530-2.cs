    using Windows10Interop;
    using System.Diagnostics;
    ...
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            private void buttonRight_Click(object sender, EventArgs e) {
                var curr = Desktop.FromWindow(this.Handle);
                Debug.Assert(curr.Equals(Desktop.Current));
                var right = curr.Right;
                if (right == null) right = Desktop.FromIndex(0);
                if (right != null) {
                    right.MoveWindow(this.Handle);
                    right.MakeVisible();
                    this.BringToFront();
                    Debug.Assert(right.IsVisible);
                }
            }
    
            private void buttonLeft_Click(object sender, EventArgs e) {
                var curr = Desktop.FromWindow(this.Handle);
                Debug.Assert(curr.Equals(Desktop.Current));
                var left = curr.Left;
                if (left == null) left = Desktop.FromIndex(Desktop.Count - 1);
                if (left != null) {
                    left.MoveWindow(this.Handle);
                    left.MakeVisible();
                    this.BringToFront();
                    Debug.Assert(left.IsVisible);
                } 
            }
    
            private void buttonCreate_Click(object sender, EventArgs e) {
                var desk = Desktop.Create();
                desk.MoveWindow(this.Handle);
                desk.MakeVisible();
                Debug.Assert(desk.IsVisible);
                Debug.Assert(desk.Equals(Desktop.Current));
            }
    
            private void buttonDestroy_Click(object sender, EventArgs e) {
                var curr = Desktop.FromWindow(this.Handle);
                var next = curr.Left;
                if (next == null) next = curr.Right;
                if (next != null && next != curr) {
                    next.MoveWindow(this.Handle);
                    curr.Remove(next);
                    Debug.Assert(next.IsVisible);
                }
            }
        }
