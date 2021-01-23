    public sealed class ReusableFormContainer<T> : IDisposable
        where T : Form, new()
    {
        private bool isDisposed;
        private void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            Form = null;
        }
        public T Form { get; private set; }
        public void Show()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(null);
            }
            if (Form == null)
            {
                Form = new T { WindowState = FormWindowState.Minimized };
                Form.FormClosing += HandleFormClosing;
                Form.Show();
            }
            else
            {
                Form.WindowState = FormWindowState.Minimized;
            }
            Form.WindowState = FormWindowState.Normal;
        }
        public void Dispose()
        {
            // IDisposable.Dispose is implemented to handle cases, when you want to close
            // wrapped form using code
            if (!isDisposed)
            {
                Form?.Dispose();
                isDisposed = true;
            }
        }
    }
