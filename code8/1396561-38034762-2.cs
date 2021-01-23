    public static class XEvents
    {
        public static EventHandler<CommandContext> CommandCTX { get; set; }
        public static void NotifyNewCommmandContext(this CommandContext ctx, [CallerMemberName] string caller = "")
        {
            if (CommandCTX != null) CommandCTX(caller, ctx);
        }
    }
