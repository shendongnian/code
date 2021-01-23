    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            if(customClass != null && customClass.employee != null)
                base.Text = value + " - " + customClass.employee.userId;
            else
                base.Text = value;
        }
    }
