    public static Dictionary<string, Type> PrimitiveTypes = new Dictionary<string, Type>
          {
             {"int",typeof(int)},
             {"string",typeof(string)}
          };
    
        public static void Main(string[] args)
        {
            DataTable dtColorList = new DataTable();
    
            string[,] values = new string[,] { { "ID", "int" }, { "Name", "string" } };
            AddDataTableColWithType(dtColorList, values);
    
            Console.ReadLine();
        }
    
        public static void AddDataTableColWithType(DataTable dtName, string[,] colNameAndType)
        {
            for (int i = 0; i < colNameAndType.Length / 2; i++)
            {
                dtName.Columns.Add(colNameAndType[i, 0], PrimitiveTypes[colNameAndType[i, 1]]);
            }
        }
