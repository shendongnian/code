    public class SomeView
    {
        string db;
        dynamic fieldBox = null;
        dynamic valueBox = null;
        dynamic dbValues = null;
        dynamic MessageBox = null;
        private void LoadDB()
        {
            //Structure
            string myStruct = "NAME\nAGE\nSEX\nSKILL";
            db = "John\t20\tMale\tNoob\n" +
                           "Joe\t20\tMale\tMedium\n" +
                           "Jessica\t27\tFemale\tExpert\n" +
                           "John\t21\tMale\tMedium";
            //Load struct to combobox
            string[] mbstr = myStruct.Split('\n');
            for (int i = 0; i < mbstr.Length; i++)
            {
                fieldBox.Items.Add(mbstr[i]);
            }
            string[] db2 = db .Split('\n');
            for (int i = 1; i < db2.Length - 1; i++)
            {
                var data = db2[i].Split('\t'); //expensive only do once
                //Display name and age in combobox
                dbValues.Items.Add(data[0] + " - " + data[1]);
            }
        }
        protected string Transform(string value, int row, int column, string replacement, out string old)
        {
            var rows = value.Split('\n');
            var columns = rows[row].Split('\t');
            old = columns[column];
            columns[column] = replacement;
            rows[row] = string.Join("\t", columns);
            return string.Join("\n", rows);
        }
        void ValueBoxKeyDown(object sender, dynamic e)
        {
            if (e.KeyCode != "enter")
                return;
            string old;
            string newValue = this.Transform(db, dbValues.SelectedIndex, fieldBox.SelectedIndex, valueBox.Text, out old);
            MessageBox.Show("Value set: " + old + " to " + valueBox.Text + ".");
        }
    }
