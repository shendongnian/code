    public static class LaunchingCommands
    {
        public static void LaunchLocationDetailsCommand_WithParameters(object pobjObject)
        {
            System.Diagnostics.Debug.WriteLine("SomeProperty1 = " + (pobjObject as MyView2).SomeProperty1);
        }
    }
