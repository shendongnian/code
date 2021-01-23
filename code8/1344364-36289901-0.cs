        abstract class AbstractFactory  {
        	public abstract System.Data.Common.DbConnection CreateConnection(string cs);
        	public abstract System.Data.Common.DbCommand  CreateCommand(string stmt, System.Data.Common.DbConnection conn);
        }
        
        class ConcreteFactorySql : AbstractFactory {
        	public override System.Data.Common.DbConnection CreateConnection(string cs) {
        		return new SqlConnection(cs);
        	}
        	public override System.Data.Common.DbCommand CreateCommand(string stmt, System.Data.Common.DbConnection conn) {
        		return new SqlCommand(stmt, (SqlConnection) conn);
        	}
        }
        
        class ConcreteFactoryPg : AbstractFactory {
        	public override System.Data.Common.DbConnection CreateConnection(string cs) {
        		return new NpgsqlConnection(cs);
        	}
        	public override System.Data.Common.DbCommand CreateCommand(string stmt, System.Data.Common.DbConnection conn) {
        		return new NpgsqlCommand(stmt, (NpgsqlConnection) conn);
        	}
        }
