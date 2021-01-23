    using System.Data;
    using System.IO;
    
    
    public class FromYourFileToGrid
    {
    
     public static DataTable DataTableFromYourTextFile(string directory, char splitter=',')
     {
         DataTable result;
    
         string[] LineArray = File.ReadAllLines(directory);
    
         result = FormDataTable(LineArray, splitter);
    
         return result;
     }
    
    
     private static DataTable FormDataTable(string []LineArray, char splitter)
     {
         bool IsHeaderSet = false;
    
         DataTable dt = new DataTable();
    
         AddColumnToTable(LineArray, splitter, ref dt);
    
         AddRowToTable(LineArray, splitter, ref dt);
    
         return dt;
     }
    
    
     private static void AddRowToTable(string []valueCollection, char splitter, ref DataTable dt)
     {
    
         for (int i = 1; i < valueCollection.Length; i++)
         {
         string[] values = valueCollection[i].Split(splitter);
    
         DataRow dr = dt.NewRow();
    
         for (int j = 0; j < values.Length; j++)
         {
             dr[j] = values[j];
         }
    
         dt.Rows.Add(dr);
         }
     }
    
    
     private static void AddColumnToTable(string []columnCollection, char splitter, ref DataTable dt)
     {
         string[] columns = columnCollection[0].Split(splitter);
    
         foreach (string columnName in columns)
         {
         DataColumn dc = new DataColumn(columnName, typeof(string));
         dt.Columns.Add(dc);
         }
    
     }
    
    }
