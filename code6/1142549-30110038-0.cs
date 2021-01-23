        public static void resiseMe(Form frm, int newHeight)
        {
            new Task(() =>
            {
                int pause = 100;
                int steps = 5;
                int diff = newHeight - frm.Height;
                int adjust = diff / steps;
                for (int i = 0; i < steps; i++)
                {
                    frm.Invoke(new MethodInvoker(()=>{
                        frm.Height += adjust;
                        frm.Refresh();
                        System.Threading.Thread.Sleep(pause);
                    }));
                }
            }).Start();
        }
        protected override void OnDoubleClick(EventArgs e)
        {                
            if (thisRolled)
            {
                resiseMe(this, this.Height - 50);
            }
            else
            {
                resiseMe(this, this.Height + 50);
            }
            thisRolled = !thisRolled; // flip the thisRolled Value
            base.OnDoubleClick(e);
        }
