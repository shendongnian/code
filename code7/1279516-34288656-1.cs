    internal static class ExtenstionMethods
    {
        internal static void ClearData( this DataBoundControl control )
        {
            control.DataSource = null;
            control.DataBind();
        }
    }
