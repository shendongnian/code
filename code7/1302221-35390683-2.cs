    private void EntityPropertyChanged( object sender, PropertyChangedEventArgs e )
    {
          if (e.PropertyName == "IsSelected")
                this.Product.ValidateProperty("ProductUmDecorators");
    }
