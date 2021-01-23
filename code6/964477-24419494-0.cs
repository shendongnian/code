        private void button1_Click(object sender, EventArgs e)
        {
            using (DesignPar form = new DesignPar())
            {
                form.var = var;
                form.ShowDialog();
                var = form.var;
            }
        }
