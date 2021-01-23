        public class OfficeFormsConfig
        {
            public string Name { get; set; }
            public string[] @Fields { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        void FillOfficesCombo()
        {
            var arrViewConfigs = new List<OfficeFormsConfig>();
            //---Load from DB or File (but here is hard coded as an example)-
            arrViewConfigs.Add(new OfficeFormsConfig()
                {
                    Name = "NewYork",
                    @Fields = new string[] { "username", "dept", "deptManager", "dept_location" }
                });
            arrViewConfigs.Add(new OfficeFormsConfig()
            {
                Name = "Denver",
                @Fields = new string[] { "username", "deptManager", "Num_of_washroom" }
            });
            //---------------------------------------------------------------
            foreach (var config in arrViewConfigs)
            {
                comboBox1.Items.Add(config);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeFormsConfig cfg = comboBox1.SelectedItem as OfficeFormsConfig;
            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                ctl.Visible = cfg.Fields.Any(ctlName => ctlName == ctl.Name);
            }
        }
