    internal class Sample
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private bool m_SupressNextUp;
        private bool m_SupressNextDown;
    
        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
    
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.MouseUpExt += GlobalHook_MouseUpExt;
        }
    
        void GlobalHook_MouseUpExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_SupressNextUp)
                {
                    Console.WriteLine(@"First mouse up supress.");
                    e.Handled = true;
                    m_SupressNextDown = true;
                }
                else
                {
                    Console.WriteLine(@"Second mouse up - make it heppen.");
                    m_SupressNextDown = false;
                }
            }
        }
    
        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_SupressNextDown)
                {
                    Console.WriteLine(@"Second mouse down supress.");
                    e.Handled = true;
                    m_SupressNextUp = false;
                }
                else
                {
                    Console.WriteLine(@"First mouse down - make it heppen.");
                    m_SupressNextUp = true;
                }
            }
        }
    
        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.MouseUpExt -= GlobalHook_MouseUpExt;
    
            m_GlobalHook.Dispose();
        }
    }
