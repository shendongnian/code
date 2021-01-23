    public class ExpenseIncomeMap: EntityTypeConfiguration&lt;ExpenseIncome&gt;
    {
     public RoleConfiguration()
      {
    	HasKey(e => e.ID);
    	// etc.
      }
    }
