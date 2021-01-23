      public static class XMultiCommand
        {
            //  How can I have a shared context like this for all Commands of the group?
            public static MultiCommand SharedContext(this MultiCommand mc, Action<CommandContext> CallBack)
            {
                var cc = new CommandContext();            
                CallBack(cc);
                mc.SharedContext = cc;
                return mc;
            }
         
        }
