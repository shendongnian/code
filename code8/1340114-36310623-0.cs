        //When a new cell item has added, we save it into a dictionary
        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);
            ViewCell vc = (ViewCell)content;            
            
            if (vc != null)
            {
                BasketProduct bp = (BasketProduct)vc.BindingContext;
                if (bp != null)
                {
                    this.dicCells.Add(bp.MarkReference, content);
                }                
            }
            
        }
