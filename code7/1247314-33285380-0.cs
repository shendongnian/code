    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataSet ds = new DataSet("DateGuessConfigValues");
                DataTable playerTable = new DataTable("Players");
                ds.Tables.Add(playerTable);
                DataTable centuriesTable = new DataTable("Centuries");
                ds.Tables.Add(centuriesTable);
                playerTable.Columns.Add("Id", typeof(int));
                playerTable.Columns.Add("Name", typeof(string));
                playerTable.Columns.Add("Country", typeof(string));
                playerTable.Rows.Add(new object[] {1, "Viera", "Cuba"});
                playerTable.Rows.Add(new object[] {2, "Ron White", "USA"});
                centuriesTable.Columns.Add("Century", typeof(int));
                centuriesTable.Rows.Add(new object[] { 1900});
                centuriesTable.Rows.Add(new object[] { 2000});
                ds.WriteXml("Filename", XmlWriteMode.WriteSchema);
                ds = new DataSet();
                ds.ReadXml("Filename");
            }
        }
    }
    ​
