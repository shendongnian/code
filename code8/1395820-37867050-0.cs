    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        public class TableNameAttribute : Attribute
        {
            public TableNameAttribute(string tableName)
            {
                this.TableName = tableName;
            }
            public string TableName { get; set; }
        }
    
        [TableName("my_table_name")]
        public class SomePoco
        {
            public string FirstName { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var classInstance = new SomePoco() { FirstName = "Bob" };
                var tableNameAttribute = classInstance.GetType().GetCustomAttributes(true).Where(a => a.GetType() == typeof(TableNameAttribute)).Select(a =>
                {
                    return a as TableNameAttribute;
                }).FirstOrDefault();
    
                Console.WriteLine(tableNameAttribute.TableName != null ? tableNameAttribute.TableName : "null");
                Console.ReadKey(true);
            }
        }    
    }
