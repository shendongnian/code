        public class ShowSlide:ICommandExecutor
        {
            string url;
            Form1 form;
            AutoResetEvent done = new AutoResetEvent(false);
            public ShowSlide(Form1 form, string url)
            {
                this.url = url;
                this.form = form;
            }
            public void Execute()
            {
                // if we are not on the UI thread...
                if (form.InvokeRequired)
                {
                    // ... switch to it...
                    form.Invoke(new MethodInvoker(Execute));
                }
                else
                {
                    // .. we are on the UI thread now
                    // reused from your code
                    form.displaySlide(url);
                }
            }
        }
