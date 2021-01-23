    namespace webApiOracle.Models
    {
    	internal class employeeRepository
    	{
    		internal static IEnumerable<employee> getAllEmployees()
    		{
    			List<employee> employees = new List<employee>();
    			string sql = "SELECT * from employees";
    			OracleDataReader rdr = dataHelper.getrdr(sql);
    			if (rdr.HasRows)
    			{
    				while (rdr.Read())
    				{
    					employee emp = getEmployee(rdr);
    					employees.Add(emp);
    				}
    				rdr.Close();
    			}
    			return employees;
    		}
    
    		internal static employee getEmployee(int id)
    		{
    			employee emp = null;
    			string sql = "SELECT * from employees where employee_id = " + id;
    			OracleDataReader rdr = dataHelper.getrdr(sql);
    			if (rdr.HasRows)
    			{
    				while (rdr.Read())
    				{
    					emp = getEmployee(rdr);
    					
    				}
    				rdr.Close();
    			}
    			return emp;
    		}
    
    		internal static employee add(employee emp)
    		{
    			OracleDataAdapter oda = new OracleDataAdapter();
    			string sql = "Insert into employees ";
                sql = sql + "(EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,JOB_ID,SALARY,COMMISSION_PCT,MANAGER_ID,DEPARTMENT_ID) ";
                sql = sql + "values (EMPLOYEES_SEQ.NEXTVAL,:first_name,:last_name,:email,:phone_number,sysdate,:job_id,:salary,:commission_pct,:manager_id,:department_id)";
    			OracleConnection cn =
    			  new OracleConnection(
    				  ConfigurationManager.ConnectionStrings
    				  ["hr"].ConnectionString);
    
    			cn.Open();
    			oda.InsertCommand = new OracleCommand(sql, cn);
    			oda.InsertCommand.BindByName = true;
    			oda.InsertCommand.Parameters.Add(":first_name", emp.first_name);
    			oda.InsertCommand.Parameters.Add(":last_name", emp.last_name);
    			oda.InsertCommand.Parameters.Add(":email", emp.email);
    			oda.InsertCommand.Parameters.Add(":phone_number", emp.phone_number);
    			oda.InsertCommand.Parameters.Add(":job_id", emp.job_id);
    			oda.InsertCommand.Parameters.Add(":salary", emp.salary);
    			oda.InsertCommand.Parameters.Add(":commission_pct", emp.commission_pct);
    			oda.InsertCommand.Parameters.Add(":manager_id", emp.manager_id);
    			oda.InsertCommand.Parameters.Add(":department_id", emp.department_id);
    			int count = oda.InsertCommand.ExecuteNonQuery();
    			sql = "SELECT * from employees where employee_id = EMPLOYEES_SEQ.CURRVAL";
                OracleDataReader rdr = dataHelper.getrdr(sql);
    			if (rdr.HasRows)
    			{
    				while (rdr.Read())
    				{
    					emp = getEmployee(rdr);
    
    				}
    				rdr.Close();
    			}
    			return emp;
    		}
    	
    		internal static IEnumerable<employee> getEmployeesByVal(string key, string value)
    		{
    			List<employee> employees = new List<employee>();
    			string sql = "SELECT * from employees where " + key + " = '" + value + "'";
    			OracleDataReader rdr = dataHelper.getrdr(sql);
    			if (rdr.HasRows)
    			{
    				while (rdr.Read())
    				{
    					employee emp = getEmployee(rdr);
    					employees.Add(emp);
    				}
    				rdr.Close();
    			}
    			return employees;
    		}
    
    		private static employee getEmployee(OracleDataReader rdr)
    		{
    			employee emp = new employee
    			{
    				employee_id = rdr.GetInt32(rdr.GetOrdinal("EMPLOYEE_ID")),
    				first_name = rdr["FIRST_NAME"].ToString(),
    				last_name = rdr["LAST_NAME"].ToString(),
    				email = rdr["EMAIL"].ToString(),
    				phone_number = rdr["PHONE_NUMBER"].ToString(),
    				hire_date = rdr.GetDateTime(rdr.GetOrdinal("HIRE_DATE")),
    				job_id = rdr["JOB_ID"].ToString(),
    				salary = dataHelper.decimalnullable(rdr, "SALARY"),
    				commission_pct = dataHelper.decimalnullable(rdr, "COMMISSION_PCT"),
    				manager_id = dataHelper.intnullable(rdr, "MANAGER_ID"),
    				department_id = dataHelper.intnullable(rdr, "DEPARTMENT_ID")
    			};
    			return emp;
    		}
    	}
    }
