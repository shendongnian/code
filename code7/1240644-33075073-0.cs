    public virtual void MyBaseClassMethod()
    {
        var currType = this.GetType();
        if (currType == typeof(MyBaseClass))
        { 
            // base class instanatied directly.
        }
    }
