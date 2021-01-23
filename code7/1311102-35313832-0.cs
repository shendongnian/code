     if (DialogResult.Yes == MessageBox.Show(("Delete Account?"), "Message", MessageBoxButtons.YesNo))
                    {
                        int userId = Convert.ToInt32(dtgAccs.Rows[dtgAccs.CurrentRow.Index].Cells[0].Value);
                        Console.Write(userId);
                        db.execSQL("DELETE from Accounts WHERE ID=" + userId);
                       
                        dtgAccs.Rows.RemoveAt(dtgAccs.CurrentRow.Index);
                        MessageBox.Show("Account has been deleted.");
                    }
