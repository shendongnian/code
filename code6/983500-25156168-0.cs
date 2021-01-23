    [DataType(DataType.Date)]
    public DateTime? UpdatedOrderedDateReadOnly 
    { 
    get
    {
    if (OrderedDate != null)
                    {
                       return (Convert.ToDateTime(OrderedDate).Date);
                    }
                    return null;
    }
    }
