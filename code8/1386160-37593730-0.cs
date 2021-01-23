        protected override void OnMouseDown(MouseEventArgs e)
        {
            Console.WriteLine("IsTouch: " + IsTouch());
            base.OnMouseDown(e);
        }
        public bool IsTouch()
        {
            uint extra = GetMessageExtraInfo();
            bool isTouchOrPen = ((extra & 0xFFFFFF00) == 0xFF515700);
            if (!isTouchOrPen)
                return false;
            bool isTouch = ((extra & 0x00000080) == 0x00000080);
            return isTouch;
        }
        [DllImport("user32.dll")]
        private static extern uint GetMessageExtraInfo();
