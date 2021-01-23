    public static BackendProductCategoryList CategoryList
    {
        get
        {
            if (_list == null)
            {
                MessageBox.Show("Made new list");
                _list = new BackendProductCategoryList();
            }
            else
                MessageBox.Show("Returned old list");
            return _list;
        }
        set { _list = value; }
    }
