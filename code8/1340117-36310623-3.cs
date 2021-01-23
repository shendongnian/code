        //Put the focus on the CustomEntry control that represents de BasketProduct that they have passed
        public void SetSelected(BasketProduct bp, bool withDelay)
        {
            CustomEntry entry = null;
            entry = GetEntry(bp);
            if (entry != null)
            {
                if (withDelay)
                {
                    FocusDelay(entry);
                } else
                {
                    entry.Focus();
                }                                
            }            
        }
