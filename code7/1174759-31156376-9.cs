        private void btnAddContent_Add(object sender, EventArgs e)
        {
            TContent content = new TContent(session);
            using (frmEditTContent form = new frmEditTContent(content, truck))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    truck.TContents.Add(content);
                }
                else
                {
                    if (session.TrackingChanges)
                        session.RollbackTransaction();
                }
            }
        }
