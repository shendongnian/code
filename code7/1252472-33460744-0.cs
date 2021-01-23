    public class Item
        {
            public string Name;
            public uint Value;
    
            public Item(string name, uint value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
    
     public Dictionary<uint, Skill> Skills = new Dictionary<uint, Skill>();
     private void FormTesting_Load(object sender, EventArgs e)
            {
                
    
                Skill tempSkill= new Skill();
                tempSkill.Name = "test name";
                Skills.Add(1, tempSkill);
    
                foreach (uint val in Skills.Keys)
                {
                    comboBox1.Items.Add(new Item(Skills[val].Name,val));
                }
            }
