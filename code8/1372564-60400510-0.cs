        protected virtual void _(Events.RowSelected<FilterDAC> e)
        {
            if (e.Row != null)
            {
                FilterDAC row = e.Row as FilterDAC;
                PXDBStringAttribute.SetInputMask<FilterDAC.stringField>(e.Cache, e.Row, ">CCCC");
    /*PXStringAttribute for non DB backed fields*/
            }
        }
