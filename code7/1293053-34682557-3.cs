    Property(t => t.UF)
        .IsRequired()
        .CustomType("AnsiString")    // <--- 
        .HasMaxLength(2)
        .HasColumnType("Varchar")
        .HasColumnName("CID_UF");
