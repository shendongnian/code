        //When a new cell item has removed, we remove from the dictionary
        protected override void UnhookContent(Cell content)
        {
            base.UnhookContent(content);
            ViewCell vc = (ViewCell)content;
            if (vc != null)
            {
                BasketProduct bp = (BasketProduct)vc.BindingContext;
                if (bp != null)
                {
                    this.dicCells.Remove(bp.MarkReference);
                }
            }
        }
