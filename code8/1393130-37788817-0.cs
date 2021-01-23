            try
            {
                this.rOBATableAdapter.FillBy(this.dataSet1.ROBA, "%?" + ID.ToString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
