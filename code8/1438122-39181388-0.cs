     public bool IsPaneOpen
            {
                get { return isPaneOpen; }
                set
                {
                    this.Set<bool>(ref this._loisPaneOpendedPendingCount, value);
                }
            }
