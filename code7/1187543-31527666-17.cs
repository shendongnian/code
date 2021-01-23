        public class RaiseCurtain:ICommandExecutor, IDisposable
        {
            readonly Form2 form2;
            public RaiseCurtain( Form2 form2)
            {
                this.form2 = form2;
            }
            public void Execute()
            {
                if (form2.InvokeRequired)
                {
                    form2.Invoke(new MethodInvoker(Execute));
                }
                else
                {
                    form2.BringToFront();
                    form2.Up();
                }
            }
            public void Dispose()
            {
                form2.stateChangeDone.WaitOne();
            }
        }
        public class LowerCurtain : ICommandExecutor,IDisposable
        {
            readonly Form2 form2;
            public LowerCurtain(Form2 form2)
            {
                this.form2 = form2;
            }
            public void Execute()
            {
                if (form2.InvokeRequired)
                {
                    form2.Invoke(new MethodInvoker(Execute));
                }
                else
                {
                    form2.Down();
                }
            }
            public void Dispose()
            {
                form2.stateChangeDone.WaitOne();
            }
        }
