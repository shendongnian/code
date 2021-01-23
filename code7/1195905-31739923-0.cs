    public class Osoba
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Permissions Permission { get; set; }
        public string DisplayName { get; set; }
        public string HiddenId { get; set; }
        public Osoba()
        { }
        public Osoba(int id, string fname, string lname, Permissions p)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Permission = p;
            DisplayName = FirstName + " " + LastName;
            HiddenId = Id + "_" + Permission.GetHashCode();
        }
        public void ListaOsoba()
        {
            List<Osoba> objList = new List<Osoba>();
            Osoba nr1 = new Osoba(1, "Name", "Surname", Permissions.Administrator);
            Osoba nr2 = new Osoba(2, "Name2", "Surname2", Permissions.Uzytkownik);
            Osoba nr3 = new Osoba(3, "Name3", "Surname3", Permissions.Uzytkownik);
            objList.Add(nr1);
            objList.Add(nr2);
            objList.Add(nr3);
    
            ((ListBox)checkedListBox1).DataSource = objList;
            ((ListBox)checkedListBox1).DisplayMember = "DisplayName";
            ((ListBox)checkedListBox1).ValueMember = "HiddenId";
            MessageBox.Show(((ListBox)checkedListBox1).Text);
            MessageBox.Show(((ListBox)checkedListBox1).SelectedValue.ToString());
            
        }
    }
    public enum Permissions
    {
        Administrator,
        Uzytkownik
    }
