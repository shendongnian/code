            var list = new List<RandomClass>()
            {
                new RandomClass() {Checked = true, ValueDisplayed = "1"},
                new RandomClass() {Checked = false, ValueDisplayed = "2"},
                new RandomClass() {Checked = true, ValueDisplayed = "3"}
            };
            checkedListBox1.DataSource = list;
            checkedListBox1.DisplayMember = "ValueDisplayed";
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                checkedListBox1.SetItemChecked(i, ((RandomClass)checkedListBox1.Items[i]).Checked);
            }
            checkedListBox1.ItemCheck += (sender, e) => {
                list[e.Index].Checked = (e.NewValue != CheckState.Unchecked);
            };   
            public class RandomClass
            {
                public string ValueDisplayed { get; set; }
                public bool Checked { get; set; }
            }
     
