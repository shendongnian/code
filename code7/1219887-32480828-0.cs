    Property(t => t.PersonId).HasColumnName("PersonId");
                Property(t => t.Cellphone).HasColumnName("Cellphone");
                Property(t => t.Telephone).HasColumnName("Telephone");
                Property(t => t.Email).HasColumnName("Email");
    
                MapToStoredProcedures(t =>
                    t.Update(u =>
                        u.HasName("UpdatePerson", "dbo")
                            .Parameter(v => v.PersonId, "PersonId")
                            .Parameter(v => v.Cellphone, "Cellphone")
                            .Parameter(v => v.Telephone, "Telephone")
                            .Parameter(v => v.Email, "Email")
                            .Parameter(v => v.LogUserId, "LogUserId")
                            ));
