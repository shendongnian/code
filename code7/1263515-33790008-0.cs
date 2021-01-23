    public class PatientClientPhysicianConfiguration : 
        EntityConfigurationBase<PatientClientPhysician>
    {
        public PatientClientPhysicianConfiguration()
        {
            ToTable("patientclientphysician");
            // Composite key:
            HasKey(t => new { t.ClientId, t.PatientId, t.PhysicianId });
            Property(m => m.ClientId).HasColumnName("clientid");
            Property(m => m.PatientId).HasColumnName("patientid");
            Property(m => m.PhysicianId).HasColumnName("physicianid");
            HasRequired(m => m.Patient).WithMany().HasForeignKey(p => p.PatientId);
            HasRequired(m => m.Client).WithMany().HasForeignKey(c => c.ClientId);
            HasRequired(m => m.Physician).WithMany().HasForeignKey(p => p.PhysicianId);
        }
    }
