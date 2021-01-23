    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<TextBox> AbilitiesInput = null;
            public Form1()
            {
                InitializeComponent();
                AbilitiesInput = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4 };
                Person person = new Person();
                List<Ability> results = person.AllAbilities.Where((x, i) => x.Value > int.Parse(AbilitiesInput[i].Text)).ToList();
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public List<Ability> AllAbilities { get; set; }
            public Person()
            {
                AllAbilities = new List<Ability>();
            }
                
        }
        public class Ability
        {
            public int Id { get; set;}
            public int PersonId { get; set; }
            public int Value { get; set; }
        }
    }
