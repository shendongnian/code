        private void buttonShowPreview_Click(object sender, EventArgs e)
        {
            if (buttonShowPreview.Tag == null)
            {
                Form browserForm = new Form();
                browserForm.FormClosing += new FormClosingEventHandler(delegate(Object form, FormClosingEventArgs args)
                {
                    if (args.CloseReason == CloseReason.UserClosing)
                    {
                        args.Cancel = true;
                        browserForm.Hide();
                    }
                });
                preview = new WebBrowser();
                preview.DocumentCompleted += preview_DocumentCompleted; // handle the DocumentCompleted() event
                browserForm.Controls.Add(preview);
                preview.Dock = DockStyle.Fill;
                preview.Navigate("about:blank");
                buttonShowPreview.Tag = browserForm;
            }
            Form previewForm = buttonShowPreview.Tag as Form;
            previewForm.Size = new System.Drawing.Size(1024, 768);
            previewForm.DesktopLocation = new System.Drawing.Point(0, 0);
            previewForm.Text = "Article Preview";
            RefreshPreview();
            previewForm.Show();
        }
        private void RefreshPreview(string jumpToAnchor)
        {
            if (preview != null && preview.Parent != null)
            {
                preview.Parent.Enabled = false; // disable parent form
                preview.Document.OpenNew(true);
                preview.Document.Write(structuredContent.GetStructuredContentHTML(content, jumpToAnchor, false));
                preview.Refresh();
            }
        }
        private void preview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            if (wb.Parent != null)
            {
                wb.Parent.Enabled = true; // re-enable parent form
            }
        }
