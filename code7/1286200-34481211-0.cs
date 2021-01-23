        using System.IO;
         
        //...
        public void exportCSV()
        {
            string[,] izlaz = new string[,]
            {
                { _ime, _brojStola.ToString(), _idRezervacije.ToString(), _brojTelefona.ToString(), _datum, _rezervacijuUneo, _napomena }
            };
            string putanja = @"..\..\Datoteke\Rezervacije.csv";
            string delimiter = ",";
            int duzina = izlaz.GetLength(0);
        
            using (StreamWriter sw = new StreamWriter(putanja))
            {
                sw.WriteLine(string.Join(delimiter, izlaz[i]));
            }
        }
        static void Main(string[] args)
        {
        }
