        ToTable("myTabla");
        Property(u => u.MyField).HasColumnName("myField").HasColumnType("INTERVAL DAY TO SECOND");
        Property(u => u.MyField2).HasColumnName("myField2").HasColumnType("INTERVAL DAY TO SECOND");
        Property(u => u.MyField3).HasColumnName("myField3");
    }
}
