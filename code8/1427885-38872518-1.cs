    internal class AttachmentDataConfig : BaseConfig<AttachmentData>
    {
        public AttachmentDataConfig() : base("Attachment")
        {
            HasRequired(e => e.Perf)
                .WithOptional(e => e.Attachment)
                .WillCascadeOnDelete(true);
        }
    }
