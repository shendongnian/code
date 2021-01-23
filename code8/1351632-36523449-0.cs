    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace StartPage.CS
    {
        public partial class SetUp : Form
        {
            // Create a static array to hold the players
            public static Player[] players { get; private set; }
    
            // create lists to hold the colors for each player, as well as the comboBoxes
            List<String> colors = new List<String> { "Select Color","Red", "Blue", "Yellow", "Green" };
            List<ComboBox> combos = new List<ComboBox>();
    
            // constructor
            public SetUp()
            {
                InitializeComponent();
    
                // add colors to ComboBoxes and set the initial index
                combos.AddRange(new ComboBox[] { cboPlayer1Color, cboPlayer2Color, cboPlayer3Color, cboPlayer4Color });
                foreach (ComboBox combo in combos)
                {
                    combo.Items.AddRange(colors.ToArray());
                    combo.SelectedIndex = 0;
                    combo.SelectedIndexChanged += combo_SelectedIndexChanged;
                }
            }
    
            // eventhandling for form load
            private void SetUp_Load(object sender, EventArgs e)
            {
                // initialize the selected index to 2 players
                cboSelectPlayers.SelectedIndex = 0;
            }
    
            // handles displaying the number of players to select colors
            private void cboSelectPlayers_SelectedIndexChanged(object sender, EventArgs e)
            {
                // reset each combobox to index 0
                foreach (ComboBox cbox in combos)
                {
                    cbox.SelectedIndex = 0;
                }
    
                // Hide or Show comboboxes based on how many players are selected
                if (cboSelectPlayers.SelectedIndex == 0) // if players = 2
                {
                    lblPlayer3Select.Hide();
                    cboPlayer3Color.Hide();
                    lblPlayer4Select.Hide();
                    cboPlayer4Color.Hide();
                }
                else if (cboSelectPlayers.SelectedIndex == 1) // if players = 3
                {
                    lblPlayer3Select.Show();
                    cboPlayer3Color.Show();
                    lblPlayer4Select.Hide();
                    cboPlayer4Color.Hide();
                }
                else if (cboSelectPlayers.SelectedIndex == 2) // if players  4
                {
                    lblPlayer3Select.Show();
                    cboPlayer3Color.Show();
                    lblPlayer4Select.Show();
                    cboPlayer4Color.Show();
                }
            }
    
            // handles making sure that the same color can't be used by multiple players
            public void combo_SelectedIndexChanged(object sender, EventArgs e)
            {
                List<String> selectedColors = new List<String>();
                foreach (ComboBox cb1 in combos)
                {
                    if (cb1.SelectedIndex > 0)
                    {
                        selectedColors.Add(cb1.SelectedItem.ToString());
                    }
    
                    foreach (ComboBox cb2 in combos.Where(x => !x.Equals(cb1)))
                    {
                        if (cb2.SelectedIndex > 0)
                        {
                            if (cb1.Items.Contains(cb2.SelectedItem.ToString()))
                            {
                                cb1.Items.Remove(cb2.SelectedItem.ToString());
                            }
                        }
                    }
                }
    
                foreach (ComboBox cb in combos)
                {
                    foreach (String c in colors)
                    {
                        if (!selectedColors.Contains(c) && !cb.Items.Contains(c))
                        {
                            cb.Items.Add(c);
                        }
                    }
                }
            }
    
            // handles form validation
            private Boolean formValidation()
            {
                if (cboSelectPlayers.SelectedItem.ToString() == "2") // if number of players = 2
                {
                    // display error message if one of the players hasn't selected a color and return false
                    if (cboPlayer1Color.SelectedIndex < 1 || cboPlayer2Color.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please select a color for each player!");
                        return false;
                    }
                    else
                    {
                        players = new Player[2];
                        createPlayers(2);
                    }
                }
                else if (cboSelectPlayers.SelectedItem.ToString() == "3") // if number of players = 3
                {
                    // display error message if one of the players hasn't selected a color and return false
                    if (cboPlayer1Color.SelectedIndex < 1 || cboPlayer2Color.SelectedIndex < 1 || cboPlayer3Color.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please select a color for each player!");
                        return false;
                    }
                    else
                    {
                        players = new Player[3];
                        createPlayers(3);
                    }
                }
                else if (cboSelectPlayers.SelectedItem.ToString() == "4") // number of players = 4
                {
                    // display error message if one of the players hasn't selected a color and return false
                    if (cboPlayer1Color.SelectedIndex < 1 || cboPlayer2Color.SelectedIndex < 1 || cboPlayer3Color.SelectedIndex < 1 || cboPlayer4Color.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please select a color for each player!");
                        return false;
                    }
                    else
                    {
                        players = new Player[4];
                        createPlayers(4);
                    }
                }
    
                // if no errors were found in validation, return true
                return true;
            }
    
            // create players and add them to the static array
            private void createPlayers(int numPlayers)
            {
    
                for (int i = 0; i < numPlayers; i++)
                {
                    if (combos[i].SelectedItem.ToString() == "Red")
                    {
                        players[i] = new Player(Color.Red);
                    }
                    else if (combos[i].SelectedItem.ToString() == "Blue")
                    {
                        players[i] = new Player(Color.Blue);
                    }
                    else if (combos[i].SelectedItem.ToString() == "Yellow")
                    {
                        players[i] = new Player(Color.Yellow);
                    }
                    else if (combos[i].SelectedItem.ToString() == "Green")
                    {
                        players[i] = new Player(Color.Green);
                    }
                }
            }
    
            private void btnStart_Click(object sender, EventArgs e)
            {
                if (formValidation())
                {
                    GameBoard gameboard = new GameBoard();
                    gameboard.ShowDialog();
                    this.Close();
                }
            }    
        }
    }
