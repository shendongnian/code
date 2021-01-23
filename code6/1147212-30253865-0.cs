    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    namespace JSONFromCS
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e1)
            {
                List<Employee> eList = new List<Employee>();
                Employee e = new Employee();
                e.Name = "Minal";
                e.Age = 24;
    
                eList.Add(e);
    
                e = new Employee();
                e.Name = "Santosh";
                e.Age = 24;
    
                eList.Add(e);
    
                string ans = JsonConvert.SerializeObject(eList, Formatting.Indented);
    
                string script = "var employeeList = {\"Employee\": " + ans+"};";
                script += "for(i = 0;i<employeeList.Employee.length;i++)";
                script += "{";
                script += "alert ('Name : ='+employeeList.Employee[i].Name+' 
                Age : = '+employeeList.Employee[i].Age);";
                script += "}";
    
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(Page.GetType(), "JSON", script, true);
            }
        }
        public class Employee
        {
            public string Name;
            public int Age;
        }
    }  
