            [Flags]
            enum ActionFlags : int
            {
                DoThis = 0x00000001,
                DoThat = 0x00000010,
                DoOtherThing = 0x00000100,
                DoAnotherThing = 0x00001000,
                MaxValue = 0x00001111,
                MinValue = 0x00000000,
            }
    
            void DoStuff(ActionFlags what_to_do)
            {
                if ((int)(what_to_do) > (int)(ActionFlags.MaxValue) || 
                    (int)(what_to_do) < (int)(ActionFlags.MinValue))
                    throw new ArgumentException();
                if(what_to_do.HasFlag(ActionFlags.DoThis))
                {
                    // do this
                }
                if (what_to_do.HasFlag(ActionFlags.DoThat))
                {
                    // do that
                }
                if (what_to_do.HasFlag(ActionFlags.DoOtherThing))
                {
                    // do other thing
                }
                if (what_to_do.HasFlag(ActionFlags.DoAnotherThing))
                {
                    // do another thing
                }
            }
