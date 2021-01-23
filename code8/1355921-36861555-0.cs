    [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Category_Product", Storage = "_Category", ThisKey = "CategoryId", OtherKey = "CategoryId", IsForeignKey = true)]
    public Category Category {
        get {
            return this._Category.Entity;
        }
        set {
            Category previousValue = this._Category.Entity;
            if (((previousValue != value) || (this._Category.HasLoadedOrAssignedValue == false))) {
                this.SendPropertyChanging();
                if ((previousValue != null)) {
                    this._Category.Entity = null;
                    previousValue.Products.Remove(this);
                }
                this._Category.Entity = value;
                if ((value != null)) {
                    value.Products.Add(this);
                    this._CategoryId = value.CategoryId;
                } else {
                    this._CategoryId =
                    default (int);
                }
                this.SendPropertyChanged("Category");
            }
        }
    }
