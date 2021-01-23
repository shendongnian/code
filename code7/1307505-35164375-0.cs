     private int countPresenttudents()
        {
            int d = 0, e = 0;
            for (int i = 0; i < (dgvAttendance.Rows.Count - 1); i++)
            {
                d = Convert.ToInt32(dgvAttendance.Rows[i].Cells["Absent"].Value.ToString());
                e = e + d; //storing total qty into variable 
            }
            return e;
        }
