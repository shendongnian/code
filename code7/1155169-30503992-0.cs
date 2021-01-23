        private void myMethod(Control.ControlCollection controls, string text)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button)
                    ctrl.Enabled = ctrl.Text != text;
                if (ctrl.HasChildren)
                    myMethod(ctrl.Controls, text);
            }
        }
