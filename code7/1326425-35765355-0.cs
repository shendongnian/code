     private void TSBRekrytering_Click(object sender, EventArgs e)
        {
            FrmRekrytering RekryteringForm = new FrmRekrytering();
            RekryteringForm.Show(this);
            TSFrmMain.Visible = false;
        }
        public string toolstripvalue
        {
            get
            {
                return toolstripvalue;
            }
            set
            {
                toolStrip.Visible = Convert.ToBoolean(value);
            }
        }
