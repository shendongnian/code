    .Map(map =>
    {
        map.Properties(p => new
        {
            p.Username,
            p.AdminName
        });
        map.Property(p => p.AdminName).HasColumnName("Name");
        map.ToTable("Admin");
    }).Map(map =>
    {
        map.Properties(p => new
        {
            p.Username,
            p.StaffName,
            p.Phone,
            p.Position
        });
        map.Property(p => p.StaffName).HasColumnName("Name");
        map.ToTable("Staff");
    });
