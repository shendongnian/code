    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace Planet_of_fightcraft_final_build
    {
    /// <summary>
    /// Interaction logic for PartySelectionScreen.xaml
    /// </summary>
    public partial class PartySelectionScreen : Window
    {
        public PartySelectionScreen()
        {
            InitializeComponent();
        }
    
        // When the partySelectionScreen is loaded
        // it will deserialize and read the NameData.xml file
        // and will populate the charName and charStats textboxes
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    
    
            XmlSerializer sr = new XmlSerializer(typeof(NameSavingInformation));
            FileStream read = new FileStream("NameData.xml",
                FileMode.Open, FileAccess.Read, FileShare.Read);
    
            NameSavingInformation nameInfo = (NameSavingInformation)sr.Deserialize(read);
            charNameTextBox.Text = nameInfo.GeneratedName;
    
            // Setting the values of the user characters stats 
            // ucs = user class stats
            userClassStats ucs = new userClassStats();
    
            /*------Character Stats------*/
            ucs.H = 200;
            ucs.AP = 75;
            ucs.CA = 125;
            ucs.S = 100;
            //---------------------------//
    
            string health = "Health: " + ucs.H;
            string attackPower = "Attack Power: " + ucs.AP;
            string criticalAttack = "Critical Power: " + ucs.CA;
            string speed = "Speed: " + ucs.S;
            /*------Character Stats------*/
    
            string nl = "\n \n";
            charStatsTextBox.Text =
                health + nl +
                attackPower + nl +
                criticalAttack + nl +
                speed;
        }
    
    
    
        // This sets a limit on how many party memebers can be added into the listbox at one time
        public int limit = 10;
        public string limitMsg = "You have reached the maxmimum amount of party memebers, please delete some and try again.";
    
        private void generatePartyButton_Click(object sender, RoutedEventArgs e)
        {
            // Array of party members that can be randomly generated into the listbox.
            string[] partyMembers =
            {
                "Barbarian",
                "Elf",
                "Wizard",
                "Dragon",
                "Knight"
            };
    
            Random r = new Random();
    
    
            // This checks to see if there are allready existing party members in the list box, if so it will
            // prompt the user asking them for confirmation that they want to re - generate the list.
            // If yes it will clear all the items and re add new ones.
            if (partyMembersListBox.Items.Count <= limit)
            {
                partyMembersListBox.Items.Clear();
    
                for (int i = 0; i < 1; i++)
                {
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                    partyMembersListBox.Items.Add(partyMembers[r.Next(0, 4)]);
                }
    
            }
    
    
    
        }
    
        // This will allow the user to edit the stats of the selected party memeber from the listbox
        private void editStatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (partyMembersListBox.SelectedItem.ToString() == "Barbarian")
            {
                BStatsEditing bStatsEditing = new BStatsEditing();
                bStatsEditing.Show();
            }
            else if (partyMembersListBox.SelectedItem.ToString() == "Elf")
            {
                EStatsEditing eStatsEditing = new EStatsEditing();
                eStatsEditing.Show();
            }
        }
    
        // The user can choose their team without random generation.
        // this will check to see if the count of items in the list box is less than the limit
        // if so it will manualy add the - character, else it will show a messagebox informing them
        // they have reached the maximum amount of characters and must delete some.
        private void addBarbarianButton_Click(object sender, RoutedEventArgs e)
        {
    
            if (partyMembersListBox.Items.Count < limit)
            {
                // bc = Barbarian Character.
                string bc = "Barbarian";
    
                partyMembersListBox.Items.Add(bc);
            }
            else
            {
                MessageBox.Show(limitMsg);
            }
    
        }
    
    
        // The user can choose their team without random generation.
        // this will check to see if the count of items in the list box is less than the limit
        // if so it will manualy add the - character, else it will show a messagebox informing them
        // they have reached the maximum amount of characters and must delete some.
        private void addElfButton_Click(object sender, RoutedEventArgs e)
        {
            if (partyMembersListBox.Items.Count < limit)
            {
                // ec = Elf Character.
                string ec = "Elf";
    
                partyMembersListBox.Items.Add(ec);
            }
            else
            {
                MessageBox.Show(limitMsg);
            }
        }
    
    
        // The user can choose their team without random generation.
        // this will check to see if the count of items in the list box is less than the limit
        // if so it will manualy add the - character, else it will show a messagebox informing them
        // they have reached the maximum amount of characters and must delete some.
        private void addWizardButton_Click(object sender, RoutedEventArgs e)
        {
            if (partyMembersListBox.Items.Count < limit)
            {
                // wc = Wizard Character.
                string wc = "Wizard";
    
                partyMembersListBox.Items.Add(wc);
            }
            else
            {
                MessageBox.Show(limitMsg);
            }
        }
    
    
        // The user can choose their team without random generation.
        // this will check to see if the count of items in the list box is less than the limit
        // if so it will manualy add the - character, else it will show a messagebox informing them
        // they have reached the maximum amount of characters and must delete some.
        private void addDragonButton_Click(object sender, RoutedEventArgs e)
        {
            if (partyMembersListBox.Items.Count < limit)
            {
                //dc = Dragon Character.
                string dc = "Dragon";
    
                partyMembersListBox.Items.Add(dc);
            }
            else
            {
                MessageBox.Show(limitMsg);
            }
        }
    
    
        // The user can choose their team without random generation.
        // this will check to see if the count of items in the list box is less than the limit
        // if so it will manualy add the - character, else it will show a messagebox informing them
        // they have reached the maximum amount of characters and must delete some.
        private void addKnightButton_Click(object sender, RoutedEventArgs e)
        {
            if (partyMembersListBox.Items.Count < limit)
            {
                //kc = Knight Character.
                string kc = "Knight";
    
                partyMembersListBox.Items.Add(kc);
            }
            else
            {
                MessageBox.Show(limitMsg);
            }
        }
    
    
        // This allows the user to delete one or more chosen characters from the listbox.
        private void deletePartyMember_Click(object sender, RoutedEventArgs e)
        {
            if (this.partyMembersListBox.SelectedIndex >= 0)
            {
                this.partyMembersListBox.Items.RemoveAt(this.partyMembersListBox.SelectedIndex);
            }
        }
    
        // This will save the current party members to the PartyData.txt file
        private void savePartyButton_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("PartyData.txt");
            foreach (var item in partyMembersListBox.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
        }
    
        // This will search for the PartyData.txt file 
        // if it is found it will load the party data and populate the partyMembersListBox with said data
        // if it cannot be found a messagebox will inform the user and prompt them to create a new party.
        private void loadPartyButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("PartyData.txt"))
            {
                string[] lines = File.ReadAllLines("PartyData.txt");
                foreach (string line in lines)
                {
                    partyMembersListBox.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Unable to find existing party data, please create a new party!");
            }
        }
    }
