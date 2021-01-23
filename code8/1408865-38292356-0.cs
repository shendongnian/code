    public static class ControlUtils
    {
        public static Point GetFormLocation(this Control control)
        {
            return control.FindForm().PointToClient(control.PointToScreen(control.Location));
        }
    }
