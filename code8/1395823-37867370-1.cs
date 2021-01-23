    class Program
    {
        static void Main(string[] args)
        {
            var classInstance = new SomePoco() { FirstName = "Bob" };
            var tableNameAttribute = classInstance.GetAttribute<TableNameAttribute>();
            Console.WriteLine(tableNameAttribute != null ? tableNameAttribute.TableName : "null");
            Console.ReadKey(true);
        }
    }   
