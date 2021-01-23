    static class Extensions {
        public static void BeginInvoke(this Control ctl, Action a) {
            ctl.BeginInvoke(a);
        }
    }
