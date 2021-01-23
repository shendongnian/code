    public class FormReportMapping : EntityTypeConfiguration<FormReport>
    {
        public FormReportMapping()
        {
            Property(x => x.FormEntryId)
                .HasColumnName("FormEntry_Id")
                .HasColumnAnnotation("ForeignKey", "FormEntry");
            // ...
        }
    }
