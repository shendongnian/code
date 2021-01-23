        public static IEnumerable<Control> WalkControls(this Control topControl)
        {
            if (topControl == null)
                yield break;
            yield return topControl;
            foreach (var child in topControl.Controls.OfType<Control>())
                foreach (var subChild in WalkControls(child))
                    yield return subChild;
        }
        public static void SetControlTreeBackColor<TControl>(Control topControl, Color color) where TControl : Control
        {
            foreach (var childControl in topControl.WalkControls().OfType<TControl>())
                childControl.BackColor = color;
        }
