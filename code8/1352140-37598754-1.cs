                if (e.ColumnIndex == 2 && e.RowIndex == this.dataGridView1.NewRowIndex)
                {
                    double precio = Convert.ToDouble("0");
                    dataGridView1["Column7", e.RowIndex].Value = (precio.ToString());
                }
            }
}
