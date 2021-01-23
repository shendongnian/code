    Property(t => t.UF)
        .IsRequired()
        .IsUnicode(false)            // <--- 
        .HasMaxLength(2)
        .HasColumnType("Varchar")
        .HasColumnName("CID_UF");
