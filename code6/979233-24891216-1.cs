    public partial class FormCheckList : Form
    {
        Dictionary<string, string[]> myDictionary;
        public FormCheckList()
        {
            InitializeComponent();
            InitializeArrays();
        }
        private void InitializeArrays()
        {
            myDictionary = new Dictionary<string, string[]>();
            myDictionary.Add("Tumu", new string[] { "Jane", "Tom", "Danny", "John", "Jacyln", "Lily", "Lale" });
            myDictionary.Add("Idari", new string[] { "Jane", "Tom", "Danny" });
            myDictionary.Add("Teknik", new string[] { "John", "Jacyln", "Lily", "Lale" });       
        }
        private void checkedListBoxLevelOne_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string selectedItem = checkedListBoxLevelOne.SelectedItem.ToString();
            string[] items = myDictionary[selectedItem];
            checkedListBoxLevelTwo.Items.Clear();
            listBox.Items.Clear();
            for (int i = 0; i < items.Length; i++)
            {
                checkedListBoxLevelTwo.Items.Add(items[i]);
                checkedListBoxLevelTwo.SetItemChecked(i, true);
                listBox.Items.Add(items[i]);
            }
        }
        
    }
