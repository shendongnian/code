    public DataTable DataService()
    {
        var data = new DataTable();
        var startPath = Application.StartupPath;
        string folderName = Path.Combine(startPath, "POI_List");
        System.IO.Directory.CreateDirectory(folderName);
        string SavedfileName = "POI_list.json";
        var Saving_path = Path.Combine(folderName, SavedfileName);
        string fileName = "Zensus_Gemeinden_org.xlsx";
        var path = Path.Combine(startPath, fileName);
        String name = "Gemeinden_31.12.2011_Vergleich";
        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                       path + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand oconn = new OleDbCommand("Select [3] as City,[4] as Population, * From [" + name + "$D7:E11300] Where [4] > 10000", con);
        con.Open();
        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
        //DataTable data = new DataTable();
        sda.Fill(data);
        string Place_Json = "Place_List:" + JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(Saving_path, Place_Json);
        return data;
      }
   }
    public partial class Form1 : Form
