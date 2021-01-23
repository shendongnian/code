    public class PictureConfig : ComplexTypeConfiguration<Picture>
    {
        public PictureConfig()
        {
            Property(t => t.Type).HasColumnName("PictureType");
            Property(t => t.Content).HasColumnName("PictureContent");
        }
    }
