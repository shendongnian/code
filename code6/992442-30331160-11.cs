     internal bool isFlowSuppressed 
        { 
            get 
            { 
                return (_flags & Flags.IsFlowSuppressed) != Flags.None; 
            }
            set
            {
                Contract.Assert(!IsPreAllocatedDefault);
                if (value)
                    _flags |= Flags.IsFlowSuppressed;
                else
                    _flags &= ~Flags.IsFlowSuppressed;
            }
        }
