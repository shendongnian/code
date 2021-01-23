        private void HideAllForms()
        {
            frm1.Hide();
            frm2.Hide();
            frm3.Hide();
            frm4.Hide();
        }
        void mytimer_Tick(object sender, EventArgs e)
        {
            if (frmSrl == 1)
            {
                frmSrl++;
                HideAllForms();
                frm1.Show();
            }
            else if (frmSrl == 2)
            {
                frmSrl++;
                HideAllForms();
                frm2.Show();
            }
            else if (frmSrl == 3)
            {
                frmSrl++;
                HideAllForms();
                frm3.Show();
            }
            else if (frmSrl == 4)
            {
                frmSrl =1;
                HideAllForms();
                frm4.Show();
            }
            else
                frmSrl = 1;
        }
        int frmSrl = 1;
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Timer mytimer = new Timer();
            mytimer.Tick += mytimer_Tick;
            mytimer.Interval = 2000;
            mytimer.Start();
        }
