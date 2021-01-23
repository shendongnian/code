        public class Player
        {
        private string first_name;
        private string middle_name;
        private string last_name;
        private DateTime dob;
        private string nat;
        private char gender;
        public Player(string first_name, string last_name, string middle_name, DateTime dob, string nat, char gender)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.middle_name = middle_name;
            this.dob = dob;
            this.nat = nat;
            this.gender = gender;
        }
        public override string ToString()
        {
            return first_name + " " + middle_name + " " + last_name + " " + dob + " " + nat + " " + gender;
        }
       private List<string> content = new List<string>();
       public string FileName { get; set; }
       public string Delimiter { get; set; }
       
       //public static class ReadCSVFile(string fn, string delim = "|")
       //{
       //    FileName = fn;
       //    Delimiter = delim;
       //}
       private void Load()
       {
           TextFieldParser par = new TextFieldParser(FileName);
           par.TextFieldType = FieldType.Delimited;
           par.SetDelimiters(Delimiter);
           while (!par.EndOfData)
           {
               string[] fields = par.ReadFields();
               foreach (string field in fields)
                {
                    Console.WriteLine(field);
               }
          }  
          par.Close();
        }
       public void RunReadCSVFile(string fn, string delim = "|")
       {
            //var f = ReadCSVFile(@"C:\Temp\car1.txt");
            //f.Load();
            FileName = fn;
            Delimiter = delim;
            Load();
        }
           static void Main(string[] args)
            {
                Player plr = new Player("First","Last","Middle",DateTime.Now,"nat",'G');
                plr.RunReadCSVFile(@"C:\temp\car1.txt");
            
            }
  
