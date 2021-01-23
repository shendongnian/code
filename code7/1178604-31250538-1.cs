        private void SetLocationKeys(CheckedListBox cb, DataTable dt)
        {
            int index = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r.ItemArray[2].ToString() == "1")
                {
                    cb.SetItemChecked(index, true);
                }
                index++;
            }
        }
