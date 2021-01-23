    internal class Program {
        private static void Main(string[] args) {
            DoSomething(new Control() {Parent = new Control()});
        }
        private static void DoSomething(Control control) {
            control.SomeEvent += MethodThatHandlesEvent;
            Control parentControl = control.Parent;
            parentControl.Disposed += new LambdaClass(control).OnDisposed;
        }
        private class LambdaClass {
            private readonly Control _control;
            public LambdaClass(Control control) {
                _control = control;
            }
            public void OnDisposed(object sender, EventArgs e) {
                // if MethodThatHandlerEvent is not static, you also need to pass and store reference to the wrapping class
                _control.SomeEvent -= MethodThatHandlesEvent;
            }
        }
        
        private static void MethodThatHandlesEvent(object sender, EventArgs e) {
        }
        private class Control {
            public event EventHandler SomeEvent;
            public event EventHandler Disposed;
            public Control Parent { get; set; }
        }
    }
