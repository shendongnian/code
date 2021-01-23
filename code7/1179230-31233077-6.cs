    namespace YourNamespace {
        public class TestMap : EntityTypeConfiguration<Domain.Test> {
            public TestMap() {
                ToTable("Test");
            }
        }
    }
