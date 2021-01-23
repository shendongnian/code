        void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {           
            CheckBox c = (CheckBox)sender;
            var otherCheckBoxName = typeof(EditorToolbox).GetRuntimeFields().Where(x => x.FieldType == typeof(CheckBox) && !x.Name.Equals(c.Name)).Select(x => x.Name).FirstOrDefault();
            CheckBox c2 = (CheckBox)this.Controls.Find(otherCheckBoxName, true).FirstOrDefault();
            c2.Focus();
        }
