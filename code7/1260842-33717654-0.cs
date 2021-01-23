        public static void Update(this Control ctrl, Action a)
        {
            if (ctrl.InvokeRequired) 
            { 
                ctrl.BeginInvoke(new MethodInvoker(a), null); 
            }
            else 
            { 
                a.Invoke(); 
            }
        }
