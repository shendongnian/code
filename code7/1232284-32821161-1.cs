    public void Run(BasicDTO dto)
    {
        PropertyInfo pi = dto.PropertyDTO.Where(x => x.Name == "Surname").SingleOrDefault();
        MyRows mr = new MyRows();
        mr.Val = pi.GetValue(dto);//Here I need reference
    }
