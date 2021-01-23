    public partial class DefaultDatePaymentCardTransaction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Payment.PaymentCardTransaction", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
        }
    
        public override void Down()
        {
            AlterColumn("Payment.PaymentCardTransaction", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
