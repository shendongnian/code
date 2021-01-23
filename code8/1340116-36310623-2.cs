        //Retrieves a CustomEntry control that are into the collection and represents the BasketProduct that we have passed
        public CustomEntry GetEntry(BasketProduct bp)
        {
            CustomEntry ce = null;
            if (bp != null && this.dicCells.ContainsKey(bp.MarkReference))
            {
                ViewCell vc = (ViewCell)this.dicCells[bp.MarkReference];
                if (vc != null)
                {
                    ce = (CustomEntry)((Grid)((StackLayout)vc.View).Children[0]).Children[4];
                }
            }
            return ce;
        }
