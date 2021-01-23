    private BindingList<string> titles;
    public BindingList<string> Titles { 
        get 
        {
            if(titles == null)
            {
                titles = new BindingList<string>();
            }
            return titles;
        }
    }
