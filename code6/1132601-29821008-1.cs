    namespace Extensions
    {
        public static class FormExtensions
        {
            public static void HideAll(this Control[] controls)
            {
                foreach(var control in controls)
                {
                    control.Visible = false;
                }
            }
        }
    }
