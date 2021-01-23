    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReportFileRequest>()
            .HasKey(i => new { i.ReportId, i.FileRequestId });
        model.Entity<ReportFileRequest>()
           .HasRequired(i => i.Report)
           .WithMany(i => i.ReportFileRequests)
           .WithForeignKey(i => i.ReportId)
           .WillCascadeOnDelete(true);
        model.Entity<ReportFileRequest>()
           .HasRequired(i => i.FileRequest)
           .WithMany(i => i.ReportFileRequests)
           .WithForeignKey(i => i.FileRequestId)
           .WillCascadeOnDelete(false);
    }
