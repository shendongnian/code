    public class Student
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string mestoRodjenja { get; set; }
        public string JMBG { get; set; }
        public string brojIndeksa { get; set; }
        public string adresa { get; set; }
        public string grad { get; set; }
        public string brojTelefona { get; set; }
        public string brojMobilnog { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dic=new Dictionary<string,Student>();
            var student1 = new Student
            {
                adresa = "adresa",
                JMBG = "1234",
                prezime = "prezime",
                datumRodjenja = DateTime.Now
            };
            var student2= new Student
            {
                adresa = "adresa",
                JMBG = "4567",
                prezime = "prezime",
                datumRodjenja = DateTime.Now
            };
            dic.Add(student1.JMBG,student1);
            dic.Add(student2.JMBG,student2);
            dic.Save("test.xml"); //save sample
            dic.Clear();
            dic.Load("test.xml"); //load sample
            var student3 = new Student
            {
                adresa = "adresa",
                JMBG = "9012",
                prezime = "prezime",
                datumRodjenja = DateTime.Now
            };
            dic.Add(student3.JMBG,student3); //adding new student 
                dic.Save("test.xml"); //saving again to add recently added student
        }
