    protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
    {
         base.OnElementChanged(e);
    
         if (this.Control == null) return;
    
         this.Control.TableFooterView = new UIView();
    }
