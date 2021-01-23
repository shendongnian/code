        public class ManagerUserMap : EntityMapBase<ManagerUser>
        {
            protected override void SetupMappings()
            {
                base.SetupMappings();
                this.HasKey(t => t.Id);
                this.ToTable("ManagerUsers");
                this.Property(t => t.Id).HasColumnName("ManagerUsersID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
                this.Property(t => t.Title).HasColumnName("txtTitle");
                this.HasRequired(x => x.StaffDetails)
                    .WithMany()
                    .HasForeignKey(x => x.UserCode);
            }
        }
        public class StaffMap : EntityMapBase<Staff>
        {
            protected override void SetupMappings()
            {
                base.SetupMappings();
                this.HasKey(t => t.Id);
                this.ToTable("TblStaff");
                this.Property(t => t.Id).HasColumnName("StaffID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
                this.Property(t => t.UserCode).HasColumnName("User_Code");
                this.Property(t => t.DateOfBirth).HasColumnName("dob");
            }
        }
